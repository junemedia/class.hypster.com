using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class mixManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public mixManagement()
        {
        }




        public List<Mix_Mobile> GetRandomMixes(int p_limiter = 10)
        {
            List<Mix_Mobile> mixes_list = new List<Mix_Mobile>();

            mixes_list = hyDB.sp_Mix_GetRandomMixes(p_limiter).ToList();

            return mixes_list;
        }


        public List<hypster_tv_DAL.Mix_GetGenresAndCovers> GetGenresAndCovers(int p_limiter = 30)
        {
            List<hypster_tv_DAL.Mix_GetGenresAndCovers> genres_list = new List<hypster_tv_DAL.Mix_GetGenresAndCovers>();

            genres_list = hyDB.sp_Mix_GetGenresAndCovers(p_limiter).ToList();

            return genres_list;
        }



        public void ReportSong(hypster_tv_DAL.Radio_Usage p_radio_usage)
        {
            hyDB.Radio_Usage.AddObject(p_radio_usage);
            hyDB.SaveChanges();
        }




    }
}
