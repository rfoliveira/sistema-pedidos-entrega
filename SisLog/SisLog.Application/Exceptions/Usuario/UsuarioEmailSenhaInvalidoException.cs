namespace SisLog.Application.Exceptions.Usuario;

internal class UsuarioEmailSenhaInvalidoException : ApplicationException
{
    public UsuarioEmailSenhaInvalidoException() : base("Email ou senha inválidos")
    {
    }
}
