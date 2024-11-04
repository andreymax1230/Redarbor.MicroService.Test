using MediatR;
using Redarbor.Events;
using Redarbor.Kafka.Eda.Attribute;
using Redarbor.Kafka.Eda.Interface;
using Redarbor.Kafka.Eda.Model;
using Redarbor.Kafka.Eda.Utilities;
using Redarbor.System.Application.Employee.Commands;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Integrator.Mapper;

namespace Redarbor.System.Integrator.EventIntegrator;

[KafkaTopicAttribute(EmployeeEvent.CreateEmployee)]
public class CreateEmployeeIntegrator : BaseIntegrator, IKafkaEvent
{
    public CreateEmployeeIntegrator(IMediator mediator, IKafkaProducerService kafkaProducerService) : base(mediator, kafkaProducerService) {}

    public async Task Handler(KafkaMessage meesage, CancellationToken token)
    {
        var entityMessage = meesage.Value.ToDeserializeJSON<RequestCreateEmployeeDto>();
        var entityMap = MapperConfig.Mapper.Map<CreateEmployeeCommand>(entityMessage);
        var response = await _mediator.Send(entityMap);
        response.Topic = EmployeeEvent.GenerateGenericSucessEvent;
        await _kafkaProducerService.PublishAsync(EmployeeEvent.GenerateGenericSucessEvent, response);
    }
}