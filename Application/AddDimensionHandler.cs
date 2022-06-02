using Context.FakeData;
using DataTransferObject;
using Entity;
using MediatR;
using Unit = MediatR.Unit;

namespace Application;

public class AddDimensionHandler : IRequestHandler<AddDimensionRequestDto>
{
    public Task<Unit> Handle(AddDimensionRequestDto request, CancellationToken cancellationToken)
    {
        var unit = FakeData.Units.Find(u => u.Id == request.UnitId);
        ArgumentNullException.ThrowIfNull(unit);
        FakeData.Dimensions.Add(new Dimension
        {
            Id = FakeData.Dimensions.Max(d => d.Id) + 1,
            UnitId = request.UnitId,
            EnName = request.EnName,
            FaName = request.FaName,
            UnitSymbol = unit.Symbol,
            UnitEnName = unit.EnName,
            UnitFaName = unit.FaName
        });

        return Unit.Task;
    }
}