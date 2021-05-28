using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Factory;
using ELibrary.Model;

namespace ELibrary.Controller
{
    public class CMD_AdminLogin
    {
        Repository<CLS_AdminLogin> cmd = new Repository<CLS_AdminLogin>();

      public  List<CLS_AdminLogin> GetAllAdmins()
        {
            return cmd.GetAll("GetAllAdminUser").ToList();
        }
    }
}