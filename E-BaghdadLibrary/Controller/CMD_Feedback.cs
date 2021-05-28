using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Model;
using ELibrary.Factory;
namespace ELibrary.Controller
{
    public class CMD_Feedback
    {
        Repository<CLS_Feedback> cmd = new Repository<CLS_Feedback>();

      public  void InsertFeedback(CLS_Feedback feedback)
        {
            cmd.ExcParam("SP_InsertFeedback @username,@feed,@email", feedback);
        }
    }
}