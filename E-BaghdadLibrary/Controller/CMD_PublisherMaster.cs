using ELibrary.Factory;
using ELibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.Controller
{
    public class CMD_PublisherMaster
    {
        Repository<CLS_PublisherMaster> cmd = new Repository<CLS_PublisherMaster>();

        public List<CLS_PublisherMaster> GetAllPublisher()
        {
            return cmd.GetAll("SP_GetAllPublisher").ToList();
        }

        public void InsertPublisher(CLS_PublisherMaster publisher)
        {
            cmd.ExcParam("SP_InsertPublisher @publisher_id,@publisher_name", publisher);
        }

        public void UpdatePublisher(CLS_PublisherMaster publisher)
        {
            cmd.ExcParam("SP_UpdatePublisher @publisher_id,@publisher_name", publisher);
        }

        public void DeletePublisher(CLS_PublisherMaster publisher)
        {
            cmd.ExcParam("SP_DeletePublisher @publisher_id", publisher);
        }
    }
}