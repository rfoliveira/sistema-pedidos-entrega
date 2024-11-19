namespace SisLog.Application.Exceptions.Usuario;

public class UsuarioNaoEncontradoException : ApplicationException
{
    public UsuarioNaoEncontradoException(string fieldName, Object fieldValue) : base($"Usuário com {fieldName} {fieldValue} não encontrado")
    {
    }
}
