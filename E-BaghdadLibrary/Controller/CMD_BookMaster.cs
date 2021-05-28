using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Model;
using ELibrary.Factory;
namespace ELibrary.Controller
{
    public class CMD_BookMaster
    {
        Repository<CLS_BookMaster> cmd = new Repository<CLS_BookMaster>();

      public  List<CLS_BookMaster> GetAllBooks()
        {
            return cmd.GetAll("SP_GetAllBooks").ToList();
        }

        public void InsertBook(CLS_BookMaster book)
        {
            cmd.ExcParam("SP_InsertBooks @book_id, @book_name, @genre , @author_name, @publisher_name , @publisher_date, @language, @edition, @book_cost, @no_of_page, @book_description, @actual_stock, @current_stock, @book_img_link", book);
        }

        public void UpdateBook(CLS_BookMaster book)
        {
            cmd.ExcParam("SP_UpdateBooks @book_id, @book_name, @genre , @author_name, @publisher_name , @publisher_date, @language, @edition, @book_cost, @no_of_page, @book_description, @actual_stock, @current_stock, @book_img_link", book);
        }

        public void DeleteBook(CLS_BookMaster book)
        {
            cmd.ExcParam("SP_DelteBooks @book_id", book);
        }

        public void SubCurrentStock(string book_id)
        {
            cmd.ExcParam("SP_SubCurrentStock @book_id", new CLS_BookMaster() { 
            book_id = book_id
            }) ;
        }
    }
}