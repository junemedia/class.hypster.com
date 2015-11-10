using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class featuredContentManagement
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public featuredContentManagement()
        {
            
        }


        public List<FeaturedContent> ReturnFeaturedContent(int sontType)
        {
            List<FeaturedContent> fc_list = new List<FeaturedContent>();


            fc_list = hyDB.sp_FeaturedContent_ReturnFeaturedContent(sontType).ToList();


            return fc_list;
        }


        public void delete_fc(int fc_id)
        {
            hyDB.sp_FeaturedContent_delete_fc(fc_id);
        }



        



    }
}
