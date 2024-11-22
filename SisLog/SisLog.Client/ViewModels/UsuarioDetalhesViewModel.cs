using System;

namespace SisLog.Client.ViewModels
{
    public class UsuarioDetalhesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public DateTime? RemovidoEm { get; set; }
    }
}