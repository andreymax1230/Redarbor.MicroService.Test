using Bogus;
using Redarbor.Events;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.UnitTest.Fake;

internal static class EmployeeByIdFaker
{
    private static Guid IdEvent = Guid.NewGuid();
    public static RequestEmployeeById GenerateItemFake(this Faker<RequestEmployeeById> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Id, 1);
        return item.Generate();
    }

    public static ResponseEmployeeDto GenerateItemFake(this Faker<ResponseEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Topic, z => EmployeeEvent.GenerateGenericSucessEvent);
        item.RuleFor(x => x.Response, z => new Faker<EmployeeExtendDto>().ItemEmployeeFaker());
        return item;
    }

    private static EmployeeExtendDto ItemEmployeeFaker(this Faker<EmployeeExtendDto> item)
    {
        item.RuleFor(x => x.Id, z => 1);
        item.RuleFor(x => x.UserName, z => z.Lorem.Lines(2));
        item.RuleFor(x => x.Name, z => z.Lorem.Lines(5));
        return item.Generate();
    }
}