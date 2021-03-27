using Interfaces.Services;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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