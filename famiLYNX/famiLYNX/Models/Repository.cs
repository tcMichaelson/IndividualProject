using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    //This will eventually populate any lists or fields that need
    //to be set.
    public class Repository {
        public Member GetMember() {
            return new Member {
                FirstName = "Tom",
                LastName = "Michaelson",
                UserAddress = GetAddress(),
                UserName = "tmichael"
            };
        }

        public Address GetAddress() {
            return new Address { City = "Plano", State = StName.Illinois, Street = "1507 Prairie Wind Dr." };
        }

        public Conversation GetConversation() {
            var memberToUse = GetMember();
            return new Conversation {
                MessageList = new List<Message> { GetMessage() },
                Topic = "Some Topic",
                AttenderList = new List<Member> { memberToUse },
                ContributorList = new List<Member> { memberToUse },
                CreatedBy = memberToUse,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                Id = 123,
                IsEvent = true,
                VisibleTo = new List<Member> { memberToUse }
            };
        }

        public Family GetFamily() {
            return new Family {
                ConversationList = new List<Conversation> { GetConversation() },
                MemberList = new List<Member> { GetMember() },
                OrgName = "Michaelson"
            };
        }

        public Message GetMessage() {
            return new Message {
                Contributor = GetMember(),
                Text = "This is some text, but I don't know why."
            };
        }
    }
}