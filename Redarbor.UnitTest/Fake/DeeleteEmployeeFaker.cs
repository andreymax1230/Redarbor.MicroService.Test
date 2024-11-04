using Bogus;
using Redarbor.Events;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.UnitTest.Fake;

internal static class DeeleteEmployeeFaker
{
    private static Guid IdEvent = Guid.NewGuid();

    public static RequestDeleteEmployeeDto GenerateItemFake(this Faker<RequestDeleteEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Id, z => 1);
        return item.Generate();
    }

    public static ResponseDeleteEmployeeDto GenerateItemFake(this Faker<ResponseDeleteEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Topic, z => EmployeeEvent.GenerateGenericSucessEvent);
        item.RuleFor(x => x.Response, z => true);
        return item.Generate();
    }
}