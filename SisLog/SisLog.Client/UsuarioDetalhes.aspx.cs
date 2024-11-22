using RestSharp;
using SisLog.Client.ViewModels;
using System;
using System.Configuration;

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
                Usuario = GetUsuarioDetalhe(int.Parse(Request.QueryString["id"]));
            }
        }

        private static UsuarioDetalhesViewModel GetUsuarioDetalhe(int usuarioId)
        {
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            var client = new RestClient($"{apiUrl}/usuarios/{usuarioId}");

            return client.GetAsync<UsuarioDetalhesViewModel>(apiUrl).Result;
        }
    }
}