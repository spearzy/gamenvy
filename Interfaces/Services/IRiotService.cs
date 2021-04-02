using SharedObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IRiotService
    {
        Task<string> getTFTStats(string input);
        Task<List<ValorantCharacterDto>> GetValorantCharacters();
    }
}
