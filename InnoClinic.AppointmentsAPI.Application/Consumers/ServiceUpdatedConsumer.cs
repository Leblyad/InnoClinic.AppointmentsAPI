using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.SharedModels;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace InnoClinic.AppointmentsAPI.Application.Consumers
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdatedMessage>
    {
        private readonly ILogger<ServiceUpdatedConsumer> _logger;
        private readonly IAppointmentRepository _appointmentRepository;

        public ServiceUpdatedConsumer(ILogger<ServiceUpdatedConsumer> logger, IAppointmentRepository appointmentRepository)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
        }

        public async Task Consume(ConsumeContext<ServiceUpdatedMessage> context)
        {
            var serviceUpdatedMessage = context.Message;

            var appointment = await _appointmentRepository.SearchAppointmentsByField("Approve", trackChanges: true);
            appointment = appointment.Where(s => s.ServiceId.ToString() == serviceUpdatedMessage.Id.ToString());

            foreach (var app in appointment)
            {
                app.ServiceName = serviceUpdatedMessage.ServiceName;
            }

            await _appointmentRepository.SaveAsync();

            Console.WriteLine("Consumed message from InnoClinic.ServicesAPI: Model - {0}, Id - {1}, ServiceName - {2}",
                nameof(ServiceUpdatedMessage), serviceUpdatedMessage.Id.ToString(), serviceUpdatedMessage.ServiceName);

            _logger.LogInformation("Consumed message from InnoClinic.ServicesAPI: Model - {0}, Id - {1}, ServiceName - {2}",
                nameof(ServiceUpdatedMessage), serviceUpdatedMessage.Id.ToString(), serviceUpdatedMessage.ServiceName);
        }
    }

}
