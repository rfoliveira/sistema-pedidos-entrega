using System;

namespace SisLog.Client.ViewModels
{
    public class PedidoDetalheViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataHoraEntrega { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public int? NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public DateTime? RemovidoEm { get; set; }
    }
}