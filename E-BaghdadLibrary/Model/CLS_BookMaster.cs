﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.Model
{
    public class CLS_BookMaster
    {
        public string book_id { get; set; }
        public string book_name { get; set; }
        public string genre { get; set; }
        public string author_name { get; set; }
        public string publisher_name { get; set; }
        public string publisher_date { get; set; }
        public string language { get; set; }
        public string edition { get; set; }
        public string book_cost { get; set; }
        public string no_of_page { get; set; }
        public string book_description { get; set; }
        public string actual_stock { get; set; }
        public string current_stock { get; set; }
        public string book_img_link { get; set; }
    }
}