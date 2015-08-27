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

        public Member GetMember(string uName) {
            foreach (var user in new List<Member> { GetMember() }) {
                if (user.UserName == uName) {
                    return user;
                }
            }
            return new Member { };
        }

        public Address GetAddress() {
            return new Address { City = "Plano", State = StName.Illinois, Street = "1507 Prairie Wind Dr." };
        }

        public List<Conversation> GetConversation() {
            var memberToUse = GetMember();
            return new List<Conversation> {
                new Conversation {
                MessageList = GetMessage(),
                Topic = "Some Topic",
                AttenderList = new List<Member> { memberToUse },
                ContributorList = new List<Member> { memberToUse },
                CreatedBy = memberToUse,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                Id = 123,
                IsEvent = true,
                VisibleTo = new List<Member> { memberToUse }
            },
            new Conversation {
                MessageList = GetMessage(),
                Topic = "Some Second Topic",
                AttenderList = new List<Member> { memberToUse },
                ContributorList = new List<Member> { memberToUse },
                CreatedBy = memberToUse,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                Id = 124,
                IsEvent = true,
                VisibleTo = new List<Member> { memberToUse }
            }
            };
        }

        public Family GetFamily() {
            return new Family {
                ConversationList = GetConversation(),
                MemberList = new List<Member> { GetMember() },
                OrgName = "Michaelson"
            };
        }

        public IList<Message> GetMessage() {
            return new List<Message> {
                new Message {
                    Contributor = GetMember(),
                    Text = "This is some text, but I don't know why."
                },
                new Message {
                    Contributor = GetMember(),
                    Text = "This is a second set of text."
                }
            };
        }
    }
}