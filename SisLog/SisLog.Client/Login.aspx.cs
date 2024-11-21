using System;
using System.Web.Security;

namespace SisLog.Client
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectFromLoginPage(TxtEmail.Value, false);
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (IsValidCredentials(TxtEmail.Value, TxtSenha.Value))
            {
                FormsAuthentication.RedirectFromLoginPage(TxtEmail.Value, false);
            }
            else
            {
                LblErrorMessages.Text = "Login e/ou senha inválidos";
            }
        }

        private static bool IsValidCredentials(string email, string senha)
        {
            return email == "rafael@teste.com" && senha == "123456";
        }
    }
}