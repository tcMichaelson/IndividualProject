using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class Message {
        public string Text { get; set; }
        public Member Contributor { get; set; }
    }
}