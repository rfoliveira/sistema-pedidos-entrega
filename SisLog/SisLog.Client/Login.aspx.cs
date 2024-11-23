using SisLog.Client.Services;
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
                FormsAuthentication.RedirectFromLoginPage(GetUserFromEmail(TxtEmail.Value), CbxLembrar.Checked);
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (IsValidCredentials(TxtEmail.Value, TxtSenha.Value))
            {
                FormsAuthentication.RedirectFromLoginPage(GetUserFromEmail(TxtEmail.Value), CbxLembrar.Checked);
            }
            else
            {
                LblErrorMessages.Text = "Login e/ou senha inválidos";
            }
        }

        private static bool IsValidCredentials(string email, string senha)
        {
            return UsuarioService.Instancia().Login(email, senha).IsAuthenticated;
        }

        private static string GetUserFromEmail(string email) => email.Split('@')[0];
    }
}