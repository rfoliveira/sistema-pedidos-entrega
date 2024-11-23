using Microsoft.Ajax.Utilities;
using RestSharp;
using RestSharp.Authenticators;
using SisLog.Client.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web;

namespace SisLog.Client.Services
{
    public sealed class PedidosService
    {
        public static PedidosService _instance = null;
        private readonly string _apiUrl;
        private IRestClient _client;
        private const string ENDPOINT = "pedidos";
        private readonly string _token;

        private PedidosService(string token)
        {
            _token = token;
            _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

            var authenticator = new JwtAuthenticator(_token);
            var options = new RestClientOptions(_apiUrl)
            {
                Authenticator = authenticator
            };

            _client = new RestClient(options);
        }

        public static PedidosService Instancia(string token)
        {
            if (_instance == null)
                return new PedidosService(token);

            return _instance;
        }

        ~PedidosService()
        {
            DisposeResources();
        }

        private void DisposeResources()
        {
            _client?.Dispose();
        }

        private void CheckToken()
        {
            if (_token.IsNullOrWhiteSpace())
                throw new HttpException("Token não definido");
        }

        public IEnumerable<PedidoDetalheViewModel> GetAllByUsuario(int usuarioId)
        {
            CheckToken();
            return _client.Get<IEnumerable<PedidoDetalheViewModel>>(ENDPOINT, new { usuarioId });
        }

        public PedidoDetalheViewModel GetById(int id)
        {
            CheckToken();
            return _client.Get<PedidoDetalheViewModel>(ENDPOINT, new { id });
        }

        public bool Update(PedidoDetalheViewModel pedido)
        {
            var request = new RestRequest(ENDPOINT, Method.Put);
            request.AddJsonBody(pedido);

            var response = _client.Put(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public bool Delete(int id)
        {
            var request = new RestRequest(ENDPOINT, Method.Delete);
            request.AddParameter("id", id);

            var response = _client.Delete(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public bool SetEntrega(int id)
        {
            var request = new RestRequest(ENDPOINT + "/entrega", Method.Patch);
            request.AddParameter("id", id);

            var response = _client.Patch(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}