using Interfaces.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedObjects.DTOs;
namespace gamenvy.Pages.Games.Riot
{
    public partial class Valorant : ComponentBase
    {
        [Inject] IRiotService RiotService { get; set; }
        
        List<ValorantCharacterDto> CharacterList { get; set; }

        protected async override Task OnInitializedAsync()
        {
        //    CharacterList = await RiotService.GetValorantCharacters();
        }

    }
}
