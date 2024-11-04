namespace Redarbor.RequestReply.Eda.Helper;

public static class HelperRequestReply
{
    public static string CreateEventId => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 24);
}
