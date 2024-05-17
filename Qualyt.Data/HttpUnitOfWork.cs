using Microsoft.AspNetCore.Http;
using AspNet.Security.OpenIdConnect.Primitives;

namespace Qualyt.Data
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(MCADbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        }
    }
}
