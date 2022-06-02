using MediatR;

namespace DataTransferObject;

public class AddDimensionRequestDto : IRequest
{
    public long UnitId { get; set; }
    public string FaName { get; set; } = null!;
    public string EnName { get; set; } = null!;
}