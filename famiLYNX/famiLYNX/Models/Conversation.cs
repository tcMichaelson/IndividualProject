using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class Conversation {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedDate { get; set; }
        public Member CreatedBy { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsEvent { get; set; }
        public List<Message> MessageList { get; set; }
        public List<Member> ContributorList { get; set; }
        public List<Member> VisibleTo { get; set; }
        public List<Member> AttenderList { get; set; }
    }
}