using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Zeng.Prototypes.Projection.Projections;
using Zeng.Prototypes.Projection.Readers;

namespace Zeng.Prototypes.Projection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<IEventHeaderReader, EventHeaderReader>();
            builder.Services.AddScoped<IEventMessageReader, EventMessageReader>();

            builder.Services.Scan(s => s.FromAssemblyOf<IProjection>()
                .AddClasses(c => c.AssignableTo<IProjection>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            builder.Services.AddScoped<IOrchestrator, Orchestrator>();
            
            //todo: add automapper
        }
    }
}