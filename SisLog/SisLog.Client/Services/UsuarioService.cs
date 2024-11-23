using Microsoft.Ajax.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using SisLog.Client.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web;

namespace SisLog.Client.Services
{
    public sealed class UsuarioService
    {
        private static UsuarioService _instance = null;
        private readonly string _apiUrl;
        private IRestClient _clientJwt;
        private IRestClient _client;
        private const string ENDPOINT = "usuarios";
        private string _token;
        public bool IsAuthenticated => !string.IsNullOrEmpty(_token);

        public static UsuarioService Instancia()
        {
            if (_instance == null)
                return new UsuarioService();

            return _instance;
        }

        private UsuarioService()
        {
            _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            _client = new RestClient(_apiUrl);
        }

        ~UsuarioService()
        {
            DisposeResources();
        }

        private void DisposeResources()
        {
            _client?.Dispose();
            _clientJwt?.Dispose();
        }

        public UsuarioService SetToken(string token)
        {
            _token = token;
            return this;
        }

        public UsuarioService Login(string email, string senha)
        {
            var request = new RestRequest(ENDPOINT + "/login", Method.Post);
            request.AddJsonBody(new { email, senha });

            var response = _client.ExecutePost(request);

            if (response.IsSuccessStatusCode)
            {
                _token = response.Content;
                SetJwtOptions();
            }

            return this;
        }

        private void CheckToken()
        {
            if (_token.IsNullOrWhiteSpace())
                throw new HttpException("Token não definido");
        }

        private void SetJwtOptions()
        {
            var authenticator = new JwtAuthenticator(_token);
            var options = new RestClientOptions(_apiUrl)
            {
                Authenticator = authenticator
            };
            _clientJwt = new RestClient(options);
        }

        public IEnumerable<UsuarioDetalhesViewModel> GetAll()
        {
            CheckToken();
            return _clientJwt.Get<IEnumerable<UsuarioDetalhesViewModel>>(ENDPOINT);
        }

        public UsuarioDetalhesViewModel GetUsuarioById(int id)
        {
            CheckToken();
            return _clientJwt.Get<UsuarioDetalhesViewModel>(ENDPOINT, new { id });
        }

        public bool Register(string nome, string email, string senha)
        {
            var request = new RestRequest(ENDPOINT + "/register", Method.Post);
            request.AddJsonBody(new { nome, email, senha });

            var response = _client.Post<UsuarioDetalhesViewModel>(request);

            return response.Id > 0;
        }

        public bool Update(UsuarioDetalhesViewModel usuario)
        {
            var request = new RestRequest(ENDPOINT, Method.Put);
            request.AddJsonBody(usuario);

            var response = _clientJwt.Put(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public bool Delete(int id)
        {
            var request = new RestRequest(ENDPOINT, Method.Delete);
            request.AddParameter("id", id);

            var response = _clientJwt.Delete(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}