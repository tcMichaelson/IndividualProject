﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class CreateMessageViewModel {
        public string MessageText { get; set; }
        public int ConversationId { get; set; }
        public int FamilyId { get; set; }
        public string MemberUserName { get; set; }
    }
}