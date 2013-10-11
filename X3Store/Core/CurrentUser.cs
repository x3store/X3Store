using System.Web;

namespace X3Store.Web.Core
{
    public static class CurrentUser
    {
        public static bool IsAuthenticated { get { return HttpContext.Current.Request.IsAuthenticated; } }
        public static bool IsClient { get { return HttpContext.Current.User.IsInRole("Client"); } }
        public static bool IsCurrentUserManager { get { return HttpContext.Current.User.IsInRole("Manager"); } }
        public static bool IsCurrentUserAdministrator { get { return HttpContext.Current.User.IsInRole("Administrator"); } }
    }
}