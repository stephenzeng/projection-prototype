using System;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Zeng.Prototypes.Projection.Startup))]
namespace Zeng.Prototypes.Projection
{
    public class ProjectionFunction
    {
        private readonly IOrchestrator _orchestrator;

        public ProjectionFunction(IOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        [FunctionName(nameof(ProjectionFunction))]
        public async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger logger)
        {
            try
            {
                await _orchestrator.ExecuteAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
