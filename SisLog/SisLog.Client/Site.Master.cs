using System;
using System.Web.Security;
using System.Web.UI;

namespace SisLog.Client
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}