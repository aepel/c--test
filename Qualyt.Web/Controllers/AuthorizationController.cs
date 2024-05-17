using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNet.Security.OpenIdConnect.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using Qualyt.Domain.Models.Users;
using Qualyt.Data.Core;
using System;
using Qualyt.Domain.Models.Mails;
using Qualyt.Domain.Models.Mails.Interfaces;
using Qualyt.Web.Helpers;
using Qualyt.Services.Services;
using System.Web;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Qualyt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AuthorizationController : Controller
    {
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateService _templateservice;

        public AuthorizationController(
            IOptions<IdentityOptions> identityOptions,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
             IEmailSender emailSender,
             IEmailTemplateService templateServices
             )
        {
            _identityOptions = identityOptions;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _templateservice=templateServices;
        }


        [HttpPost("~/connect/token")]
        [Produces("application/json")]
        public async Task<IActionResult> Exchange(OpenIdConnectRequest request)
        {
            try { 
                if (request.IsPasswordGrantType())
                {
                    var user = await _userManager.FindByEmailAsync(request.Username) ?? await _userManager.FindByNameAsync(request.Username);
                    if (user == null)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "Please check that your email and password is correct"
                        });
                    }

                    // Ensure the user is enabled.
                    if (!user.Enabled)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "The specified user account is disabled"
                        });
                    }


                    // Validate the username/password parameters and ensure the account is not locked out.
                    var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

                    // Ensure the user is not already locked out.
                    if (result.IsLockedOut)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "The specified user account has been suspended"
                        });
                    }

                    // Reject the token request if two-factor authentication has been enabled by the user.
                    if (result.RequiresTwoFactor)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "Invalid login procedure"
                        });
                    }

                    // Ensure the user is allowed to sign in.
                    if (result.IsNotAllowed)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "The specified user is not allowed to sign in"
                        });
                    }

                    if (!result.Succeeded)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "Please check that your email and password is correct"
                        });
                    }



                    // Create a new authentication ticket.
                    var ticket = await CreateTicketAsync(request, user);

                    return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
                }
                else if (request.IsRefreshTokenGrantType())
                {
                    // Retrieve the claims principal stored in the refresh token.
                    var info = await HttpContext.AuthenticateAsync(OpenIddictServerDefaults.AuthenticationScheme);

                    // Retrieve the user profile corresponding to the refresh token.
                    // Note: if you want to automatically invalidate the refresh token
                    // when the user password/roles change, use the following line instead:
                    // var user = _signInManager.ValidateSecurityStampAsync(info.Principal);
                    var user = await _userManager.GetUserAsync(info.Principal);
                    if (user == null)
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "The refresh token is no longer valid"
                        });
                    }

                    // Ensure the user is still allowed to sign in.
                    if (!await _signInManager.CanSignInAsync(user))
                    {
                        return BadRequest(new OpenIdConnectResponse
                        {
                            Error = OpenIdConnectConstants.Errors.InvalidGrant,
                            ErrorDescription = "The user is no longer allowed to sign in"
                        });
                    }

                    // Create a new authentication ticket, but reuse the properties stored
                    // in the refresh token, including the scopes originally granted.
                    var ticket = await CreateTicketAsync(request, user);

                    return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
                }
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    ErrorDescription = "The specified grant type is not supported"
                });
            }
            catch(Exception e)
            {
                var error= @"Se cacheo excepción:"+Environment.NewLine;
                while (e.InnerException != null) {
                    error += e.Message+"-|"+Environment.NewLine;
                    e = e.InnerException;
                }
                error += e.Message;
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    ErrorDescription = error
                });
            }
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> SendPasswordResetLink(string unEmail)
        {
            try
            {
                var mailDelForm = Request.Form["usermail"][0];
                ApplicationUser user = await _userManager.FindByEmailAsync(mailDelForm);
                if (user == null)
                {
                    return BadRequest(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant,
                        ErrorDescription = "No se encontro ningun usuario con este mail"
                    });
                }
                var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                var resetLink = Url.Action("ResetPassword","test",
                         new { token = token , userid=user.Id },
                         protocol: HttpContext.Request.Scheme);
                resetLink=resetLink.Replace("test/", "");
                EmailBuilder builder = new EmailBuilder();
                builder.AddDestino(user.Email);
                builder.SetRemitente("info@qualyt.com");
                builder.SetTemplate(_templateservice.GetTemplate(TipoEmailTemplate.PasswordRecovery));
                builder.AddElementoSubject(new UrlLink(resetLink, user.Name));
                builder.AddElementoBody(new UrlLink(resetLink,user.Name));
                Email mail = builder.Build();
                await _emailSender.SendEmailAsync(mail);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = e.Message
                });
            }
        }

     
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword(string userid, string token, string nuevoPassword)
        {   var id= Request.Form["userid"][0];
            var eltoken = HttpUtility.UrlDecode(Request.Form["token"][0]);
            
            Utilities.CreateLogger<EmailSender>().LogError(LoggingEvents.SEND_EMAIL, "este es el token sin decodear" + Request.Form["token"][0], "logenproduccion");
            Utilities.CreateLogger<EmailSender>().LogError(LoggingEvents.SEND_EMAIL, "este es el token decodeado " + eltoken, "logenproduccion");
            var password = Request.Form["nuevoPassword"][0];
            ApplicationUser user = _userManager.FindByIdAsync(id).Result;
            var result =   _userManager.ResetPasswordAsync(user, eltoken, password).Result;
            if (!result.Succeeded)
            {  result = _userManager.ResetPasswordAsync(user, Request.Form["token"][0], password).Result;
                if(!result.Succeeded)
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.InvalidGrant,
                    ErrorDescription = result.Errors.Select(x => x.Code).Aggregate((x, y) => x + "/" + y)
                }); ;
                
            }
            return Ok();
        }
        
        private async Task<AuthenticationTicket> CreateTicketAsync(OpenIdConnectRequest request, ApplicationUser user)
        {
            
            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), OpenIddictServerDefaults.AuthenticationScheme);
            ticket.SetScopes(new[]
            {
                    OpenIdConnectConstants.Scopes.OpenId,
                    OpenIdConnectConstants.Scopes.Email,
                    OpenIdConnectConstants.Scopes.Phone,
                    OpenIdConnectConstants.Scopes.Profile,
                    OpenIdConnectConstants.Scopes.OfflineAccess,
                    OpenIddictConstants.Scopes.Roles
            }.Intersect(request.GetScopes()));
            //}

            //ticket.SetResources("quickapp-api");

            // Note: by default, claims are NOT automatically included in the access and identity tokens.
            // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
            // whether they should be included in access tokens, in identity tokens or in both.

            foreach (var claim in ticket.Principal.Claims)
            {
                // Never include the security stamp in the access and identity tokens, as it's a secret value.
                if (claim.Type == _identityOptions.Value.ClaimsIdentity.SecurityStampClaimType)
                    continue;


                var destinations = new List<string> { OpenIdConnectConstants.Destinations.AccessToken };

                // Only add the iterated claim to the id_token if the corresponding scope was granted to the client application.
                // The other claims will only be added to the access_token, which is encrypted when using the default format.
                if ((claim.Type == OpenIdConnectConstants.Claims.Subject && ticket.HasScope(OpenIdConnectConstants.Scopes.OpenId)) ||
                    (claim.Type == OpenIdConnectConstants.Claims.Name && ticket.HasScope(OpenIdConnectConstants.Scopes.Profile)) ||
                    (claim.Type == OpenIdConnectConstants.Claims.Role && ticket.HasScope(OpenIddictConstants.Claims.Roles)) ||
                    (claim.Type == CustomClaimTypes.Permission && ticket.HasScope(OpenIddictConstants.Claims.Roles)))
                {
                    destinations.Add(OpenIdConnectConstants.Destinations.IdentityToken);
                }


                claim.SetDestinations(destinations);
            }


            var identity = principal.Identity as ClaimsIdentity;


            if (ticket.HasScope(OpenIdConnectConstants.Scopes.Profile))
            {
                if (!string.IsNullOrWhiteSpace(user.UserName))
                    identity.AddClaim(CustomClaimTypes.FullName, user.UserName, OpenIdConnectConstants.Destinations.IdentityToken);

                if (!string.IsNullOrWhiteSpace(user.Id))
                    identity.AddClaim("ID", user.Id, OpenIdConnectConstants.Destinations.IdentityToken);
            }

            if (ticket.HasScope(OpenIdConnectConstants.Scopes.Email))
            {
                if (!string.IsNullOrWhiteSpace(user.Email))
                    identity.AddClaim(CustomClaimTypes.Email, user.Email, OpenIdConnectConstants.Destinations.IdentityToken);
            }

            if (ticket.HasScope(OpenIdConnectConstants.Scopes.Phone))
            {
                if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
                    identity.AddClaim(CustomClaimTypes.Phone, user.PhoneNumber, OpenIdConnectConstants.Destinations.IdentityToken);
            }
            
            return ticket;
        }
        public class UrlLink: IMaileable
        {
            public string Url {get;set;}
            public string user { get; set; }
            public UrlLink(string url,string username ){Url=url; user = username; }
            public List<Tag> getTags(){ return new List<Tag>(){new Tag("{RECOVERURL}",Url), new Tag("{FULLNAME}", user) };}
        }
    }
}