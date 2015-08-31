using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {

    public class Repository {
        private DataContext _db = new DataContext();

        //Create method
        public void CreateMessage(string msgText, string contributorUserName, int conversationId) {
            Message newMessage = new Message();
            newMessage.Contributor = GetMemberByUserName(contributorUserName);
            newMessage.Conversation = GetConversationById(conversationId);
            newMessage.Text = msgText;
            newMessage.TimeSubmitted = DateTime.Now;
            _db.Messages.Add(newMessage);
            _db.SaveChanges();
        }

        //Create method
        public void CreateConversation(CreateConversationViewModel model) {
            Conversation newConvo = new Conversation {
                Topic = model.NewTopic,
                CreatedBy = GetMemberByUserName(model.UserName),
                WhichFam = GetFamilyById(model.FamId),
                IsEvent = model.IsEvent,
                Recurs = model.Recurs,
                ExpirationDate = model.ExpirationDate,
                CreatedDate = DateTime.Now,
                MessageList = new List<Message>(),
                VisibleTo = GetFamilyById(model.FamId).MemberList,
                AttenderList = new List<Member> { GetMemberByUserName(model.UserName) }
            };
            if (model.FirstMessage != null && model.FirstMessage != "") {
                Message newMessage = new Message { Text = model.FirstMessage, Contributor = newConvo.CreatedBy, Conversation = newConvo, TimeSubmitted = DateTime.Now };
                newConvo.MessageList.Add(newMessage);
                _db.Messages.Add(newMessage);
            }
            _db.Conversations.Add(newConvo);
            _db.SaveChanges();
        }

        //List method -- need Member and Family
        public FamilyViewModel GetConversations(string userID, string famName) {
            Member member = GetMemberByUserName(userID);
            List<Family> families = GetFamilysByName(famName);
            foreach (var fam in families) {
                if (fam.MemberList.Contains(member)) {
                    var convoList = (from m in _db.Conversations where m.WhichFam.Id == fam.Id select m).Include("MessageList").ToList();
                    return new FamilyViewModel { ConversationList = convoList, FamilyId = fam.Id, FamilyName = fam.OrgName, UserName = userID };
                }
            }
            return new FamilyViewModel();
        }

        //private method
        private bool IsMemberInFamily(Member member, Family family) {
            if (member != null && family != null) {
                return member.Families.Contains(family);
            }
            return false;
        }

        //additional method
        public List<Family> GetFamilysByName(string famName) {
            return (from f in _db.Familys where f.OrgName.ToLower() == famName.ToLower() select f).Include("MemberList").ToList();
        }

        //Find method
        public int GetFamilyIdById(int id) {
            return (from f in _db.Familys where f.Id == id select f.Id).FirstOrDefault();
        }

        //Find method
        public string GetFamilyNameById(int id) {
            return (from f in _db.Familys where f.Id == id select f.OrgName).FirstOrDefault();
        }

        //Find method
        public Family GetFamilyById(int id) {
            return (from f in _db.Familys where f.Id == id select f).Include("MemberList").FirstOrDefault();
        }

        //List method - 
        public ConversationViewModel GetConversationData(int conversationId, int familyId, string familyName, string userName) {
            ConversationViewModel vm = new ConversationViewModel {
                Conversation = GetConversationById(conversationId),
                FamilyId = familyId,
                FamilyName = familyName,
                UserName = userName
            };
            return (vm);
        }

        //Find method
        public Conversation GetConversationById (int id) {
            return (from c in _db.Conversations where c.Id == id select c).Include("MessageList.Contributor").FirstOrDefault();
        }

        //Find method - additional
        public Member GetMemberByUserName (string userId) {
            return (from m in _db.Members where m.UserName == userId select m).Include("Families").FirstOrDefault();
        }
        
        //Find method
        public List<Member> GetMembersByFamilyId(int Id) {
            var fam = (from f in _db.Familys where f.Id == Id select f).FirstOrDefault();
            return (from m in _db.Members where m.Families.ToList().Contains(fam) select m).ToList();
        }

    }
}