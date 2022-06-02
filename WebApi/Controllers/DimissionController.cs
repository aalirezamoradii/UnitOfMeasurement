using DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]/[action]")]
public class DimensionController : Controller
{
    private readonly IMediator _mediator;

    public DimensionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddDimensionRequestDto request)
    {
        await _mediator.Send(request);
        return Ok();
    }
}