using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Factory;
using ELibrary.Model;
namespace ELibrary.Controller
{
    public class CMD_AuthorMaster
    {
        Repository<CLS_AuthorMaster> cmd = new Repository<CLS_AuthorMaster>();

        public List<CLS_AuthorMaster> GetAllAuthor()
        {
            return cmd.GetAll("SP_GetAllAuthors").ToList();
            //Stored Procedure 
            /*CREATE proc [dbo].[SP_GetAllAuthors]
                as
                begin

                SELECT [author_id]
                      ,[author_name]
                  FROM [dbo].[tbl_author_master]
                end
             */
        }

        public void InsertAuthor(CLS_AuthorMaster author)
        {
            cmd.ExcParam("SP_InsertAuthor @author_id,@author_name", author);
        }

        public void UpdateAuthor(CLS_AuthorMaster author)
        {
            cmd.ExcParam("SP_UpdateAuthor @author_id,@author_name", author);
        }

        public void DeleteAuthor(CLS_AuthorMaster author)
        {
            cmd.ExcParam("SP_DeleteAuthor @author_id", author);
        }
    }
}