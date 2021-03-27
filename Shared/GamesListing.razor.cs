using Interfaces.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamenvy.Shared
{
    public partial class GamesListing
    {
        [Inject] IGameService service { get; set; }

        private int test { get; set; } = 1;

        private string strin;

        protected async override Task OnInitializedAsync()
        {
            strin = await setGames();
        }

        async Task<string> setGames()
        {
            return await service.getAll(3);
        }





    }
}
