using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class userContactManagement
    {
        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public userContactManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<userContact> ActiveUserContactUs()
        {
            List<userContact> user_cont_list = new List<userContact>();

            user_cont_list = hyDB.sp_userContact_Get_ActiveUserContactUs().ToList();

            return user_cont_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public userContact Get_UserContactUs_byID(int id)
        {
            userContact cont = new userContact();

            cont = (userContact)hyDB.sp_userContact_Get_UserContactUs_byID(id).FirstOrDefault();
            if (cont == null)
                cont = new userContact();

            return cont;
        }
        //----------------------------------------------------------------------------------------------------------




        // ++++
        //----------------------------------------------------------------------------------------------------------
        public bool Deactivate_UserContactUs(int id)
        {
            hyDB.sp_userContact_Deactivate_UserContactUs(id);
            
            return true;
        }
        //----------------------------------------------------------------------------------------------------------


    }
    
}
