namespace SisLog.Application.Exceptions.Pedido;

internal class PedidoNaoEncontradoException : ApplicationException
{
    public PedidoNaoEncontradoException(string name, object value) : base($"Pedido {name} {value} não encontrado")
    {
    }
}
