namespace SisLog.Application.Exceptions.Usuario;

public class UsuarioNotFoundException : ApplicationException
{
    public UsuarioNotFoundException(string fieldName, Object fieldValue) : base($"Usuário com {fieldName} {fieldValue} não encontrado")
    {
    }
}
