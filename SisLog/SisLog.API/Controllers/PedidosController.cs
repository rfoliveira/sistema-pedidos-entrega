using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisLog.Application.Commands.Pedido;
using SisLog.Application.Queries.Pedido;
using SisLog.Application.Responses.Pedido;
using System.Net;

namespace SisLog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PedidosController : ControllerBase
{
    private readonly IMediator _mediatr;

    public PedidosController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{usuarioId}")]
    [ProducesResponseType(typeof(IEnumerable<PedidoResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPedidosUsuarioAsync(int usuarioId)
    {
        var query = new GetPedidosByUsuarioQuery(usuarioId);
        var pedidos = await _mediatr.Send(query);

        return Ok(pedidos);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PedidoResponse), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreatePedidoAsync([FromBody] CreatePedidoCommand pedido)
    {
        var pedidoNovo = await _mediatr.Send(pedido);
        return CreatedAtRoute(new { usuarioId = pedido.UsuarioId }, pedidoNovo);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePedidoCommand pedido)
    {
        await _mediatr.Send(pedido);
        return NoContent();
    }

    [HttpPatch("entrega")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateEntregaAsync([FromBody] UpdateEntregaCommand dadosEntrega)
    {
        await _mediatr.Send(dadosEntrega);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mediatr.Send(new DeletePedidoCommand(id));
        return NoContent();
    }
}
