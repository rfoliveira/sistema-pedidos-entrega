using SisLog.Client.Services;
using SisLog.Client.ViewModels;
using System;

namespace SisLog.Client
{
    public partial class UsuarioDetalhes : System.Web.UI.Page
    {
        public UsuarioDetalhesViewModel Usuario;
        public string Action;
        public bool IsReadonly => Action != "Edit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Action = Request.QueryString["action"];
                Usuario = UsuarioService.Instancia().GetUsuarioById(int.Parse(Request.QueryString["id"]));
            }
        }
    }
}