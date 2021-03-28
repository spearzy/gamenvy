using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Games
    {
        public int GamesID { get; set; }
        public string GameName { get; set; }
        public int ImageID { get; set; }

        [ForeignKey(nameof(ImageID))]
        public Image Image { get; set; }

    }
}
