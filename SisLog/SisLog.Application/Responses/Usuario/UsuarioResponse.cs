namespace SisLog.Application.Responses.Usuario;

public record UsuarioResponse(
    int Id,
    string Nome,
    string Email,
    DateTime CriadoEm,
    DateTime? AtualizadoEm,
    DateTime? RemovidoEm
) : BaseResponse(Id, CriadoEm, AtualizadoEm, RemovidoEm);