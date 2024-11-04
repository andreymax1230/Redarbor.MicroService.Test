using MediatR;
using Redarbor.Kafka.Eda.Interface;

namespace Redarbor.System.Integrator.EventIntegrator;

public class BaseIntegrator
{
    protected readonly IMediator _mediator;
    protected readonly IKafkaProducerService _kafkaProducerService;

    public BaseIntegrator(IMediator mediator, 
                          IKafkaProducerService kafkaProducerService)
    {
        _mediator = mediator;
        _kafkaProducerService = kafkaProducerService;
    }
}