using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Factory;
using ELibrary.Model;

namespace ELibrary.Controller
{
    public class CMD_BookIssue
    {
        Repository<CLS_BookIssue> cmd = new Repository<CLS_BookIssue>();

       public List<CLS_BookIssue> GetAllIssuingBooks()
        {
            return cmd.GetAll("SP_GetAllIssuingBooks").ToList();
        }

        public void InsertBookIssue(CLS_BookIssue issue)
        {
            cmd.ExcParam("SP_InsertIssueBook @member_id,@member_name,@book_id,@book_name,@issue_date,@due_date", issue);
        }
        public void UpdateBookIssue(CLS_BookIssue issue)
        {
            cmd.ExcParam("SP_UpdateIssueBook @member_id,@member_name,@book_id,@book_name,@issue_date,@due_date", issue);
        }

        public void DeleteIssueBookAndIncrementCuurenStock(CLS_BookIssue issue)
        {
            cmd.ExcParam("SP_DeleteIssueBookAndIncrementCuurenStock @member_id,@book_id", issue);
        }
    }
}

        
