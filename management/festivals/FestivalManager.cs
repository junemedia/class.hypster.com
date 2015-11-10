using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class FestivalManager
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------

        public FestivalManager()
        {
        }



        public List<Festival> GetAllFestivals()
        {
            List<Festival> charts_list = new List<Festival>();

            charts_list = hyDB.sp_Festivals_GetAllFestivals().ToList();

            return charts_list;
        }




        public List<Festival> GetTopFestivals()
        {
            List<Festival> charts_list = new List<Festival>();

            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetTopFestivals"] != null)
            {
                charts_list = (List<Festival>)i_chache["GetTopFestivals"];
            }
            else
            {
                charts_list = hyDB.sp_Festivals_GetTopFestivals().ToList();
                i_chache.Add("GetTopFestivals", charts_list, DateTime.Now.AddSeconds(10000));
            }


            return charts_list;
        }








        public void AddNewFestivals(Festival p_festival)
        {
            hyDB.Festivals.AddObject(p_festival);
            hyDB.SaveChanges();
        }


        public void SaveFestival(Festival festival_update)
        {
            hyDB.sp_Festivals_SaveFestival(festival_update.Festival_ID, festival_update.Festival_Category_ID, festival_update.Festival_Name, festival_update.Festival_Desc, festival_update.Festival_Date, festival_update.Festival_User_ID, festival_update.Festival_Playlist_ID);
        }


        public void DeleteFestival(int chart_id)
        {
            hyDB.sp_Festivals_DeleteFestival(chart_id);
        }




        public Festival GetFestivalByGuid(string festival_guid)
        {
            Festival festival = new Festival();

            festival = hyDB.sp_Festivals_GetFestivalByGuid(festival_guid).FirstOrDefault();
            if (festival == null)
                festival = new Festival();

            return festival;
        }




    }
}
