using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.Model
{
    public class CLS_BookIssue
    {
        public string member_id { get; set; }
        public string member_name { get; set; }
        public string book_id { get; set; }
        public string issue_date { get; set; }
        public string due_date { get; set; }
        public string book_name { get; set; }

    }
}