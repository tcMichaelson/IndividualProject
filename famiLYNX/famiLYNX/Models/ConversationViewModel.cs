using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class ConversationViewModel {
        public Conversation Conversation { get; set; }
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
    }
}