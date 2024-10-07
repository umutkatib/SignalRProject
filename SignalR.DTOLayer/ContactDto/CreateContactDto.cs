﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DTOLayer.ContactDto
{
    public class CreateContactDto
    {
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactFooterDescription { get; set; }
    }
}
