using System;
using X3Store.Configurations;

namespace X3Store.Web
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteTitle.Text = Configs.Interface.SiteTitle;
        }
    }
}