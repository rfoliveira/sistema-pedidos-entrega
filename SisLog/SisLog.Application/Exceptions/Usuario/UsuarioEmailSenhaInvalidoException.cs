namespace SisLog.Application.Exceptions.Usuario;

public class UsuarioEmailSenhaInvalidoException : ApplicationException
{
    public UsuarioEmailSenhaInvalidoException() : base("Email ou senha inválidos")
    {
    }
}
