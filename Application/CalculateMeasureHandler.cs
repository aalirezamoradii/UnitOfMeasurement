using Common;
using Context.FakeData;
using DataTransferObject;
using MediatR;

namespace Application;

public class CalculateMeasureHandler : IRequestHandler<CalculateMeasureRequestDto, CalculateMeasureResultDto>
{
    public Task<CalculateMeasureResultDto> Handle(CalculateMeasureRequestDto request, CancellationToken ct)
    {
        var fromUnit = FakeData.Units.Find(u => u.Id == request.UnitId);
        ArgumentNullException.ThrowIfNull(fromUnit);

        var toUnit = FakeData.Units.Find(u => u.Id == request.ToUnitId);
        ArgumentNullException.ThrowIfNull(toUnit);

        if (fromUnit.ParentId != toUnit.ParentId && fromUnit.ParentId != toUnit.Id)
            throw new ArgumentException("can't measure different unit");

        var fromValue = ParserHelper.Calculate(fromUnit.ToBasic, request.Value);

        var toValue = fromUnit.ParentId != toUnit.Id 
            ? ParserHelper.Calculate(toUnit.FromBasic, fromValue) 
            : fromValue;
        return Task.Run(() => new CalculateMeasureResultDto
        {
            Value = Math.Round(toValue, 2)
        }, ct);
    }
}