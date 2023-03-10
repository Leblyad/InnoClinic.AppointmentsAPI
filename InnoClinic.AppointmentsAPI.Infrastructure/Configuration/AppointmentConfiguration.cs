using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoClinic.AppointmentsAPI.Infrastructure.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(serviceCategory => serviceCategory.Id);
            builder.HasData(new List<Appointment>()
            {
                new Appointment()
                {
                    Id = new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"),
                    DoctorId = new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"),
                    PatientId = new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"),
                    ServiceId =  new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"),
                    ServiceName = "SomeName1",
                    Status = 0,
                    Date = DateTime.Now,
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(10,0,0)
                },
                new Appointment()
                {
                    Id = new Guid("b3b0d2b0-f0f1-46ab-87d2-52c7f29cd9b8"),
                    DoctorId = new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"),
                    PatientId = new Guid("63a62769-de2a-4073-991f-c18f1a44df26"),
                    ServiceId =  new Guid("24d92a89-a088-4687-9947-08dac62592e6"),
                    ServiceName = "SomeName2",
                    Status = 0,
                    Date = new DateTime(2023,01,12),
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(11,0,0)
                },
                new Appointment()
                {
                    Id = new Guid("f84e6d4a-572e-46f1-909d-3ad50b02a88e"),
                    DoctorId = new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"),
                    PatientId = new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"),
                    ServiceId =  new Guid("24d92a89-a088-4687-9947-08dac62592e6"),
                    ServiceName = "SomeName2",
                    Status = 0,
                    Date = new DateTime(2023,01,10),
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(12,0,0)
                },
                new Appointment()
                {
                    Id = new Guid("54d11f1b-ef2b-4edd-906c-307b86e2da50"),
                    DoctorId = new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"),
                    PatientId = new Guid("63a62769-de2a-4073-991f-c18f1a44df26"),
                    ServiceId =  new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"),
                    ServiceName = "SomeName1",
                    Status = 0,
                    Date = new DateTime(2023,01,11),
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(13, 0, 0)
                },
                new Appointment()
                {
                    Id = new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"),
                    DoctorId = new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"),
                    PatientId = new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"),
                    ServiceId =  new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"),
                    ServiceName = "SomeName1",
                    Status = 0,
                    Date = DateTime.Now,
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(14, 0, 0)
                },
                new Appointment()
                {
                    Id = new Guid("7c567279-5584-4aa3-bb02-7052e866eab3"),
                    DoctorId = new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"),
                    PatientId = new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"),
                    ServiceId =  new Guid("24d92a89-a088-4687-9947-08dac62592e6"),
                    ServiceName = "SomeName2",
                    Status = 0,
                    Date = new DateTime(2023,01,10),
                    OfficeId = "639990c96e070a016e91e332",
                    Time = new TimeSpan(15, 0, 0)
                }
            });
        }
    }
}
