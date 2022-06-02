using MediatR;

namespace DataTransferObject;

public class AddUnitRequestDto : IRequest
{
    public string FaName { get; set; } = null!;
    public string EnName { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string FromBasic { get; set; } = null!;
    public string ToBasic { get; set; } = null!;
    public long? BasicId { get; set; }
}