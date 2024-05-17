namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string hash, string number,string url)
        {
            var path=url + "?id="+ hash;
            return path + "&number=" + number;
        }
    }
}
