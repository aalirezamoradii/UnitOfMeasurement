using Common;
using Context.FakeData;
using DataTransferObject;
using MediatR;

namespace Application;

public class AddUnitHandler : IRequestHandler<AddUnitRequestDto>
{
    public Task<Unit> Handle(AddUnitRequestDto request, CancellationToken cancellationToken)
    {
        var fromBasic = ParserHelper.ParseExpression(request.FromBasic);
        var toBasic = ParserHelper.ParseExpression(request.ToBasic);

        // test formula
        try
        {
            ParserHelper.Calculate(fromBasic, 1);
            ParserHelper.Calculate(toBasic, 1);
        }
        catch (Exception)
        {
            throw new FormatException("");
        }
        
        FakeData.Units.Add(new Entity.Unit
        {
            Id = FakeData.Units.Max(d => d.Id) + 1,
            EnName = request.EnName,
            FaName = request.FaName,
            FromBasic = fromBasic,
            ToBasic = toBasic,
            ParentId = request.BasicId,
            Symbol = request.Symbol
        });

        return Unit.Task;
    }
}