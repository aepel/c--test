using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qualyt.Web.ViewModels;
using System.Linq;

namespace Qualyt.Web.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(new PageHeader(currentPage, itemsPerPage, totalItems, totalPages)));
            response.Headers.Add("access-control-expose-headers", "Pagination"); // CORS
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("access-control-expose-headers", "Application-Error");// CORS
        }

        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext?.User?.Identities?.FirstOrDefault()?.FindFirst("sub")?.Value;
        }

        public static string GetUserId(this ControllerBase controllerBase)
        {
            return controllerBase?.HttpContext?.GetUserId();
        }

        public static string GetUserRole(this HttpContext httpContext)
        {
            return httpContext?.User?.Identities?.FirstOrDefault()?.FindFirst("role")?.Value;
        }

        public static string GetUserRole(this ControllerBase controllerBase)
        {
            return controllerBase?.HttpContext?.GetUserRole();
        }
    }
}
