using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Projections
{
    public abstract class Projection
    {
        public Task When(EventMessage e)
        {
            return Task.CompletedTask;
        }
    }
}