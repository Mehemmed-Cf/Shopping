namespace Shopping.Presentation.Helpers
{
    public static class RouteHelper
    {
        public static bool IsJsonRequest(HttpContext httpContext )
        {
            return httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
