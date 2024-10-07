using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.AboutDto
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string AboutImageURL { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
    }
}
