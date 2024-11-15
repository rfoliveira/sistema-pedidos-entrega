namespace SisLog.Application.Responses.Pedido;

public record PedidoResponse(
    int Id, 
    int Numero,
    string Descricao,
    decimal Valor,
    DateTime CriadoEm, 
    DateTime? AtualizadoEm, 
    DateTime? RemovidoEm
) : BaseResponse(Id, CriadoEm,AtualizadoEm, RemovidoEm);