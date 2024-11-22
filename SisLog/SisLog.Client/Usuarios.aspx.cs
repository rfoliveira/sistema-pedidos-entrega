using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;

namespace SisLog.Client.Scripts
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public IEnumerable<UsuarioDetalhes> Usuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (IsPostBack)
            {
                Usuarios = GetUsuarios();
            }
        }

        private IEnumerable<UsuarioDetalhes> GetUsuarios()
        {
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            var client = new RestClient(apiUrl + "/usuarios");
        }

        protected void Action_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect($"~/UsuarioDetalhes?id={e.CommandArgument}&action={e.CommandName}");
        }
    }
}