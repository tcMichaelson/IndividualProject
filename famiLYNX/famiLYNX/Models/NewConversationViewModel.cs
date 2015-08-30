using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class NewConversationViewModel {
        [Required]
        public string NewTopic { get; set; }

        [Required]
        public string FirstMessage { get; set; }
        public DateTime ExpirationDate {get;set;}
        public bool IsEvent { get; set; }



    }
}