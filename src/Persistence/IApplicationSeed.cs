using System.Threading.Tasks;

namespace Persistence
{
    public interface IApplicationSeed
    {
        Task Seed();
    }
}