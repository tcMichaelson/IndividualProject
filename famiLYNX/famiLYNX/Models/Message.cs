﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class Message {
        public int Id { get; set; }
        public string Text { get; set; }
        public Member Contributor { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public Conversation Conversation { get; set; }
    }
}