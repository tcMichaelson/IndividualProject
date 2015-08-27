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
      //public bool Recurs { get; set; }  Maybe set up an option to have an event recur to remind the organizer.
        public IList<Message> MessageList { get; set; }
        public List<Member> ContributorList { get; set; }  //may not need this.  Contributors are all family members
        public List<Member> VisibleTo { get; set; }
        public List<Member> AttenderList { get; set; }
    }
}