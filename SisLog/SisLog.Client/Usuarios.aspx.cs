using System;
using System.Collections.Generic;
using System.Web.Security;

namespace SisLog.Client.Scripts
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public IEnumerable<UsuarioDetalhes> UsuariosDetalhes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (IsPostBack)
            {
                UsuariosDetalhes = [];
            }
        }

        protected void Action_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect($"~/UsuarioDetalhes?id={e.CommandArgument}&action={e.CommandName}");
        }
    }
}