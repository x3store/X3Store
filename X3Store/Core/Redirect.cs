using System.Web;

namespace X3Store.Web.Core
{
    public static class Redirect
    {
        public static void ToLoginPage()
        {
            HttpContext.Current.Server.Transfer("/Credentials/Login.aspx");
        }

        public static void ToAccessDeniedPage()
        {
            HttpContext.Current.Server.Transfer("/Credentials/AccessDenied.aspx");
        }
    }
}