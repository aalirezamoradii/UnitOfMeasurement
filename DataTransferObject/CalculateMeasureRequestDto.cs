using MediatR;

namespace DataTransferObject;

public class CalculateMeasureRequestDto : IRequest<CalculateMeasureResultDto>
{
    public long UnitId { get; set; }
    public long ToUnitId { get; set; }
    public double Value { get; set; }
}