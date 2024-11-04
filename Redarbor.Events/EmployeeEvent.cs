namespace Redarbor.Events;

public static class EmployeeEvent
{
    public const string CreateEmployee = "Employee.Create";
    public const string GetListEmployee = "Employee.List";
    public const string GetEmployeeId = "Employee.GetId";
    public const string UpdateEmployee = "Employee.Update";
    public const string DeleteEmployee = "Employee.Delete";
    public const string GenerateGenericSucessEvent = "Employee.Generate.Generic.Success";
}