using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Zeng.Prototypes.Projection.Projections;
using Zeng.Prototypes.Projection.Readers;
using Zeng.Prototypes.Projection.Repositories;

namespace Zeng.Prototypes.Projection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<IEventHeaderReader, EventHeaderReader>();
            builder.Services.AddScoped<IEventMessageReader, EventMessageReader>();

            builder.Services.Scan(s => s.FromAssembliesOf(typeof(IRepository<>))
                .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            builder.Services.Scan(s => s.FromAssemblyOf<IProjection>()
                .AddClasses(c => c.AssignableTo<IProjection>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            builder.Services.AddScoped<IOrchestrator, Orchestrator>();
        }
    }
}