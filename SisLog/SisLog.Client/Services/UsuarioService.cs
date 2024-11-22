using RestSharp;
using RestSharp.Authenticators;
using SisLog.Client.ViewModels;
using System.Collections.Generic;
using System.Configuration;

namespace SisLog.Client.Services
{
    public sealed class UsuarioService
    {
        private static UsuarioService _instance = null;
        private readonly IRestClient _client;
        private const string ENDPOINT = "usuarios";
        private string _token;

        public static UsuarioService GetInstance()
        {
            if (_instance == null)
                return new UsuarioService();

            return _instance;
        }

        private UsuarioService()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["ApiUrl"]);
        }

        private UsuarioService GetToken(string email, string senha)
        {
            var token = _client.PostJson(ENDPOINT + "/login", new { email, senha });

            return this;
        }

        public IEnumerable<UsuarioDetalhesViewModel> GetAllAsync() 
            => _client.GetAsync<IEnumerable<UsuarioDetalhesViewModel>>(ENDPOINT).Result;

        public UsuarioDetalhesViewModel GetUsuarioPorId(int id)
            => _client.GetAsync<UsuarioDetalhesViewModel>(ENDPOINT, new { id }).Result;

        public string Login(string email, string senha)
        {
            return "";
        }
    }
}