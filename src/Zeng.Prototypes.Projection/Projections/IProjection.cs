using System.Threading.Tasks;
using Zeng.Prototypes.Projection.Common;

namespace Zeng.Prototypes.Projection.Projections
{
    public interface IProjection
    {
        Task When(EventMessage e);
    }
}