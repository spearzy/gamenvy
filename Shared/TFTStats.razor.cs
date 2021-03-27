using Interfaces.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamenvy.Shared
{
    public partial class TFTStats
    {
        [Inject] IRiotService riotService {get; set;}
        private string tftres;
        private string inputUsername;

        protected async override Task OnInitializedAsync()
        {
            //tftres = await riotService.getTFTStats();
        }

        async Task GetTFTData()
        {
            tftres = await riotService.getTFTStats(inputUsername);
        }

        //protected async override Task 
    }
}
