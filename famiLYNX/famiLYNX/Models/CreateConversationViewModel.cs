using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace famiLYNX.Models {
    public class CreateConversationViewModel {
        [Required]
        public string NewTopic { get; set; }
        public string FirstMessage { get; set; }
        public DateTime? ExpirationDate {get;set;}
        public bool IsEvent { get; set; }
        public bool Recurs { get; set; }
        public string UserName { get; set; }
        public int FamId { get; set; }
    }
}