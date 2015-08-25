using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {

    //Ditto note on FamilyType model.  This class is not necessary
    //for the sake of functionality.
    public class Role {
        public FamilyType OrgType { get; set; }
        public string RoleName { get; set; }
    }
}