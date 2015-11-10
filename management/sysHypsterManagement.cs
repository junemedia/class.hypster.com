using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class sysHypster_Management
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public sysHypster_Management()
        {
        }


        public void AddNewInstall()
        {
            hyDB.sp_sysHypster_AddNewInstall();
        }   

        public void AddNewUninstall()
        {
            hyDB.sp_sysHypster_AddNewUninstall();
        }





        public int GetSplashID()
        {
            int splash_id = 0;

            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetSplashID"] != null)
            {
                splash_id = (int)i_chache["GetSplashID"];
            }
            else
            {
                splash_id = (int)hyDB.sp_sysHypster_GetSplashID().SingleOrDefault();

                i_chache.Add("GetSplashID", splash_id, DateTime.Now.AddSeconds(450)); //7.5 mins
            }

            return splash_id;
        }


        public void SetSplashID(int p_splash_id)
        {
            hyDB.sp_sysHypster_SetSplashID(p_splash_id);
        }



    
    }
}
