using InnoClinic.AppointmentsAPI.Application.Consumers;
using InnoClinic.AppointmentsAPI.Application.Services;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Infrastructure.Repository;
using InnoClinic.AppointmentsAPI.Infrastructure.Repository.UserClasses;
using InnoClinic.AppointmentsAPI.Middlewares;
using InnoClinicAPI.AppointmentsAPI.Application.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Serilog;
using System.Net;

namespace InnoClinic.AppointmentsAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(2), retryCount: 5);

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(delay);
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAppointmentService, AppointmentService>()
                .AddPolicyHandler(GetRetryPolicy());

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IResultService, ResultService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();
        }

        public static void ConfigurePostgres(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("dbConnection"), b =>
            b.MigrationsAssembly("InnoClinic.AppointmentsAPI")));

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static void ConfigureLogger(this ILoggingBuilder logging, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            logging.ClearProviders();
            logging.AddSerilog(logger);
        }

        public static void ConfigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ServiceUpdatedConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("message-created-event", e =>
                    {
                        e.ConfigureConsumer<ServiceUpdatedConsumer>(context);
                    });
                });
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(setup =>
            {
                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                                {
                                    new OpenApiSecurityScheme
                                    { Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        },
                                        Name = "Bearer",
                                    },
                                    new List<string>()
                                }
            });

            });

        public static void ConfigureJWTAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = configuration.GetValue<string>("Routes:AuthorityRoute");
                        options.Audience = "APIClient";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidAudience = "APIClient"
                        };
                    });
        }
    }
}
