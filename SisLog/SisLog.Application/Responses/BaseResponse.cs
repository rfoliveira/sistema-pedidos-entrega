namespace SisLog.Application.Responses;

public record BaseResponse(int Id, DateTime CriadoEm, DateTime? AtualizadoEm, DateTime? RemovidoEm);