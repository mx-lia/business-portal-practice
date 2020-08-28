using Application.Common.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddTransient<IHashService, HashService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISalaryCalculationService, SalaryCalculationService>();
            return services;
        }
    }
}
