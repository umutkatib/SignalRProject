﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaID { get; set; }
        public string SocialMediaTitle { get; set; }
        public string SocialMediaURL { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}
