using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.AppointmentsAPI.Infrastructure.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Result> Results { get; set; }

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }
    }
}
