﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Foundation.Email.Models
{
    public class Mail
    {
        public string FromAddress { get; set; }

        public string ToAddress  { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

    }
}