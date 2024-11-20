using MediatR;
using SisLog.Application.Responses.Pedido;

namespace SisLog.Application.Commands.Pedido;

public record CreatePedidoCommand(
    int UsuarioId, 
    string Descricao, 
    decimal Valor,
    string Rua,
    string CEP,
    string Bairro,
    string Cidade,
    string Estado) : IRequest<PedidoResponse>;