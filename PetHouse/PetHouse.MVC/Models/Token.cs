using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHouse.API.Models
{
    public class Token
    {
        public String access_token { get; set; }
        public String token_type { get; set; }
        public int expires_in { get; set; }
        public String userName { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }
    }
}