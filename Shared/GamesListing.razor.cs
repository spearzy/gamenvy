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

        private string strin;

        //protected override void OnInitialized()
        //{
        //    strin = "Service under maintenance";
        //}
        async Task<string> setGames()
        {
            return null;
            //return await service.GetSeasonIndex();
        }





    }
}
