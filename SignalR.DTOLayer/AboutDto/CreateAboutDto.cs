using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.AboutDto
{
    public class CreateAboutDto
    {
        public string AboutImageURL { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
    }
}
