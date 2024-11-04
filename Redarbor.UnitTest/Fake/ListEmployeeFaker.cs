using Bogus;
using Redarbor.Events;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.UnitTest.Fake;
internal static class ListEmployeeFaker
{
    public static RequestListEmployeeDto GenerateItemFake(this Faker<RequestListEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => Guid.NewGuid().ToString());
        return item.Generate();
    }

    public static ResponseListEmployeeDto GenerateItemFake(this Faker<ResponseListEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(x => x.Topic, z => EmployeeEvent.GenerateGenericSucessEvent);
        item.RuleFor(x => x.Response, z => new Faker<EmployeeExtendDto>().ListItemEmployeeFaker());
        return item.Generate();

    }

    public static List<EmployeeExtendDto> ListItemEmployeeFaker(this Faker<EmployeeExtendDto> item)
    {
        item.RuleFor(x => x.Id, z => 1);
        item.RuleFor(x => x.UserName, z => z.Lorem.Lines(2));
        item.RuleFor(x => x.Name, z => z.Lorem.Lines(5));
        return item.Generate(6).ToList();
    }
}