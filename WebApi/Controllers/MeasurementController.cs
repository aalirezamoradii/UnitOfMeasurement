using DataTransferObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]/[action]")]
public class MeasurementController : Controller
{
    private readonly IMediator _mediator;

    public MeasurementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Calculate(CalculateMeasureRequestDto request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}