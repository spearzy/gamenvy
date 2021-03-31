using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamenvy.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public partial class AdminPanel
    {
    }
}
