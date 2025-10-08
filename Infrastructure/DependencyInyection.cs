using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Net;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IDollarApiService, DollarApiService>(client =>
            {
                client.BaseAddress = new Uri("https://dolarapi-fake.com/");
            })

            .AddTransientHttpErrorPolicy(policy =>
                policy.OrResult(r => r.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)))
            )

            .AddTransientHttpErrorPolicy(policy =>
                policy.CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                )
            );

            return services;
        }
    }
}
