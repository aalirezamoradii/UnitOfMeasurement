using DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]/[action]")]
public class UnitController : Controller
{
    private readonly IMediator _mediator;

    public UnitController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddUnitRequestDto request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}