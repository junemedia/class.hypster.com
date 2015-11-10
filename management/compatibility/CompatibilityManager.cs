using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class CompatibilityManager
    {
        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------

        public CompatibilityManager()
        {
        }


        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_1(int song_id)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result>();
            CompCheck_list = hyDB.sp_Compatibility_CompCheck_1(song_id).ToList();
            return CompCheck_list;
        }



        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_2(int song_id1, int song_id2)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result>();
            CompCheck_list = hyDB.sp_Compatibility_CompCheck_2(song_id1, song_id2).ToList();
            return CompCheck_list;
        }


        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_3(int song_id1, int song_id2, int song_id3)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result>();
            CompCheck_list = hyDB.sp_Compatibility_CompCheck_3(song_id1, song_id2, song_id3).ToList();
            return CompCheck_list;
        }


        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_4(int song_id1, int song_id2, int song_id3, int song_id4)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result>();
            CompCheck_list = hyDB.sp_Compatibility_CompCheck_4(song_id1, song_id2, song_id3, song_id4).ToList();
            return CompCheck_list;
        }


        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_5(int song_id1, int song_id2, int song_id3, int song_id4, int song_id5)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result>();
            CompCheck_list = hyDB.sp_Compatibility_CompCheck_5(song_id1, song_id2, song_id3, song_id4, song_id5).ToList();
            return CompCheck_list;
        }





        public List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result_Ex> CompCheck_1_Ex(int song_id)
        {
            List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result_Ex> CompCheck_list = new List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result_Ex>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["CompCheck_list_" + song_id] != null)
            {
                CompCheck_list = (List<hypster_tv_DAL.sp_Compatibility_CompCheck_Result_Ex>)i_chache["CompCheck_list_" + song_id];
            }
            else
            {
                CompCheck_list = hyDB.sp_Compatibility_CompCheck_1_Ex(song_id).ToList();

                i_chache.Add("CompCheck_list_" + song_id, CompCheck_list, DateTime.Now.AddSeconds(1800)); //30 mins
            }


            return CompCheck_list;
        }



    }
}
