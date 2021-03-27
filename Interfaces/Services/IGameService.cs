using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IGameService
    {
        Task<string> getAll(int id);
        Task<string> GetSeasonIndex();
    }
}
