using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class SitemapManagement
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        public SitemapManagement()
        {
        }


        public List<Sitemap_Content> GetSitemapContent()
        {
            List<Sitemap_Content> sitemap_list = new List<Sitemap_Content>();


            sitemap_list = hyDB.sp_SitemapManagement_GetSitemapContent().ToList();


            return sitemap_list;
        }


        public void UpdateDateChanged(int sitemap_id, DateTime dt)
        {
            hyDB.sp_SitemapManagement_UpdateDateChanged(dt, sitemap_id);
        }
        

    }
}
