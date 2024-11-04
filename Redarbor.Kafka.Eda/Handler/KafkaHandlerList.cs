using Microsoft.Extensions.DependencyInjection;
using Redarbor.Kafka.Eda.Attribute;
using Redarbor.Kafka.Eda.Interface;
using System.Reflection;

namespace Redarbor.Kafka.Eda.Handler;

public class KafkaHandlerList : IKafkaHandlerList
{
    /// <summary>
    /// internal list event kafka
    /// </summary>
    private readonly Dictionary<string, List<Type>> _kafkaEvent = new();

    /// <summary>
    /// constructor list handler
    /// </summary>
    /// <param name="services">service .net Dependecy Injection</param>
    /// <param name="assemblies">List Assemblies for find service Events</param>
    /// <exception cref="Exception">List Assemby is null or empty</exception>
    public KafkaHandlerList(IServiceCollection services, params Assembly[] assemblies)
    {
        ArgumentNullException.ThrowIfNull(assemblies);
        if (assemblies.Length == 0)
            throw new Exception($"Assembly array is empty");

        var typeKafkaEvent = typeof(IKafkaEvent);
        List<string> listAssemblyName = [.. assemblies[0].GetReferencedAssemblies().Select(a => a.FullName)];
        listAssemblyName.ForEach(name =>
        {
            var listItemAssembly = Assembly.Load(name).GetTypes().Where(a => typeKafkaEvent.IsAssignableFrom(a) && a.IsClass).ToList();
            listItemAssembly.ForEach(itemAssembly =>
            {
                Add(itemAssembly);
                services.AddTransient(itemAssembly);
            });
        });
    }

    /// <summary>
    /// Add Type specific for execute handler event
    /// </summary>
    /// <param name="kafkaEdaType"></param>
    public void Add(Type kafkaEdaType)
    {
        var topicsApply = GetAttributes(kafkaEdaType);
        if (topicsApply is null || topicsApply.Length == 0)
            return;

        foreach (var topic in topicsApply)
        {
            if (!_kafkaEvent.ContainsKey(topic))
                _kafkaEvent.Add(topic, new());

            _kafkaEvent[topic].Add(kafkaEdaType);
        }
    }

    /// <summary>
    /// Get list class with topics
    /// </summary>
    /// <returns>List topic whit all class apply event</returns>
    public Dictionary<string, List<Type>> GetEvents() => _kafkaEvent;

    private static string[] GetAttributes(Type type) => type.GetCustomAttributes(typeof(KafkaTopicAttribute), false).Select(attr => ((KafkaTopicAttribute)attr).Topic).ToArray();
}