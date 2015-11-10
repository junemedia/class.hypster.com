using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class DynamicContent_Management
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        public DynamicContent_Management()
        {
        }




        public List<DynamicContent> GetDynamicPages()
        {
            List<DynamicContent> pages_list = new List<DynamicContent>();


            pages_list = hyDB.sp_DynamicContent_GetDynamicPages().ToList();


            return pages_list;
        }


        public void DeleteDynPage(int dynPage_id)
        {
            hyDB.sp_DynamicContent_DeleteDynamicPage(dynPage_id);
        }



    }
}
