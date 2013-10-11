using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using X3Store.BLL;
using X3Store.Web.Core;

namespace X3Store.Web.Credentials
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//            if (!CurrentUser.IsAuthenticated)
//                Redirect.ToLoginPage();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var user = new User();
            
            ProfileData.DataSource = user.GetDataTable();
            ProfileData.DataBind();
        }
    }
}