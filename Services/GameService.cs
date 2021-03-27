using Interfaces.Services;
using System.Threading.Tasks;

namespace Services
{

    public class GameService : IGameService
    {
        public async Task<string> getAll(int id)
        {
            return "Hello";
        }
    }
}