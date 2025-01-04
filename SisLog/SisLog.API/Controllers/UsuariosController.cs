using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisLog.Application.Commands.Usuario;
using SisLog.Application.Exceptions.Usuario;
using SisLog.Application.Queries.Usuario;
using SisLog.Application.Responses.Usuario;
using System.Net;

namespace SisLog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediatr;

    public UsuariosController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UsuarioResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var usuarios = await _mediatr.Send(new GetAllUsuariosQuery());

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.OK)]
    [ProducesErrorResponseType(typeof(UsuarioNaoEncontradoException))]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Valor inválido");

        var query = new GetByIdUsuarioQuery(id);
        var usuario = await _mediatr.Send(query);

        return Ok(usuario);
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UsuarioResponse), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUsuarioCommand usuario)
    {
        var usuarioNovo = await _mediatr.Send(usuario);
        return CreatedAtRoute(new { id = usuarioNovo.Id }, usuarioNovo);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUsuarioCommand login)
    {
        var usuarioValido = await _mediatr.Send(login);

        var command = new CreateTokenCommand(
            usuarioValido.Id,
            usuarioValido.Nome,
            usuarioValido.Email
        );

        var token = await _mediatr.Send(command);

        return Ok(token);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUsuarioCommand usuario)
    {
        await _mediatr.Send(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("Valor inválido");

        var command = new DeleteUsuarioCommand(id);
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpGet("info")]
    public async Task<IActionResult> GetCurrentUserInfoAsync()
    {
        var claims = await _mediatr.Send(new GetCurrentUserInfoQuery());

        return Ok(claims);
    }
}
