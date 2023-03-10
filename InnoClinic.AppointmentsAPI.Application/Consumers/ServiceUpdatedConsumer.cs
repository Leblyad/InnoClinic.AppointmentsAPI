using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Enums;
using InnoClinic.SharedModels;
using MassTransit;

namespace InnoClinic.AppointmentsAPI.Application.Consumers
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdatedMessage>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public ServiceUpdatedConsumer(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Consume(ConsumeContext<ServiceUpdatedMessage> context) =>
            await _appointmentRepository
            .UpdateAppointmentsByStatusAndServiceIdAsync(StatusEnum.Approved, context.Message.Id, context.Message.Name);
    }

}
