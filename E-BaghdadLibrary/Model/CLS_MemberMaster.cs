using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.Model
{
    public class CLS_MemberMaster
    {
        public string member_id { get; set; }
        public string full_name { get; set; }
        public string dob { get; set; }
        public string contact_no { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string full_address { get; set; }
        public string password { get; set; }
        public string account_status { get; set; }
    }
}