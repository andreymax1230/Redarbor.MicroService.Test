using Bogus;
using Redarbor.Events;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.UnitTest.Fake;

internal static class PostEmployeeFaker
{
    private static Guid IdEvent = Guid.NewGuid();
    public static RequestCreateEmployeeDto GenerateItemFake(this Faker<RequestCreateEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Name, z => "test1");
        item.RuleFor(x => x.UserName, z => "test1");
        item.RuleFor(x => x.Email, z => "test1@test.com");
        item.RuleFor(x => x.Fax, z => "333.0142.001");
        item.RuleFor(x => x.Telephone, z => "+573015451");
        item.RuleFor(x => x.Password, z => "123456");
        item.RuleFor(x => x.CreatedOn, z => DateTime.Now);
        item.RuleFor(x => x.DeletedOn, z => DateTime.Now);
        item.RuleFor(x => x.Lastlogin, z => DateTime.Now);
        item.RuleFor(x => x.CompanyId, z => 1);
        item.RuleFor(x => x.PortalId, z => 1);
        item.RuleFor(x => x.RoleId, z => 1);
        item.RuleFor(x => x.StatusId, z => 1);
        return item.Generate();
    }

    public static ResponseCreateEmployeeDto GenerateItemFake(this Faker<ResponseCreateEmployeeDto> item)
    {
        item.RuleFor(x => x.EventId, z => IdEvent.ToString());
        item.RuleFor(x => x.Topic, z => EmployeeEvent.GenerateGenericSucessEvent);
        item.RuleFor(x => x.Response, z => true);
        item.RuleFor(x => x.Id, z => 1);
        return item.Generate();
    }
}
