using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {

    public class Role {
        public int Id { get; set; }
        public FamilyType OrgType { get; set; }
        public string RoleName { get; set; }
    }
}