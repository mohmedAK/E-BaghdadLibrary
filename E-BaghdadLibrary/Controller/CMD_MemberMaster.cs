using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELibrary.Factory;
using ELibrary.Model;
namespace ELibrary.Controller
{
    public class CMD_MemberMaster
    {

        Repository<CLS_MemberMaster> cmd = new Repository<CLS_MemberMaster>();

       public bool InsertMemberMaster(CLS_MemberMaster memberMaster)
        {
            try
            {
                cmd.ExcParam("SP_InsertMemberMaster @full_name , @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status", memberMaster);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

       public List<CLS_MemberMaster> GetAllMemberMaster()
        {
           return cmd.GetAll("SP_GetAllMemberMaster").ToList();
        }

        public void UpdateMemberStatus(CLS_MemberMaster memberMaster)
        {
            cmd.ExcParam("SP_UpdateMemberStatus @member_id,@account_status", memberMaster);
        }
        
        public bool UpdateMemberMaster(CLS_MemberMaster memberMaster)
        {
            try
            {
                cmd.ExcParam("SP_UpdateMemberMaster @full_name,@dob,@contact_no ,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status", memberMaster);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public void DeleteMember(CLS_MemberMaster memberMaster)
        {
            cmd.ExcParam("SP_DeleteMember @member_id", memberMaster);
        }
    }
}