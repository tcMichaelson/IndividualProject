using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class DataContext : DbContext {
        public IDbSet<Member> Members { get; set; }
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Family> Familys { get; set; }
        public IDbSet<Conversation> Conversations { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<FamilyType> FamilyTypes { get; set; }
        public IDbSet<Role> Roles { get; set; }
        
    }
}