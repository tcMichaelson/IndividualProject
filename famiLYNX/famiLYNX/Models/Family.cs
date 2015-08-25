using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class Family {
        public string OrgName { get; set; }
        public List<Member> MemberList { get; set; }
        public List<Conversation> ConversationList { get; set; }
    }
}