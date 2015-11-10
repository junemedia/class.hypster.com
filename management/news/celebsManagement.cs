using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;


namespace hypster_tv_DAL
{
    public class celebsManagement
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public celebsManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------




        
        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns latest (default 256 posts)
        /// </summary>
        /// <returns></returns>
        public List<newsCeleb> GetLatestCelebs(int p_post_num = 256)
        {
            List<newsCeleb> posts_list = new List<newsCeleb>();

            posts_list = hyDB.sp_newsCeleb_GetLatestCelebs(p_post_num).OrderBy(m => Guid.NewGuid()).ToList();
            
            return posts_list;
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns latest 256 posts (results are cahched for 2 hours)
        /// </summary>
        /// <returns></returns>
        public List<newsCeleb> GetLatestCelebs_cache(int p_postsNum = 256)
        {
            List<newsCeleb> posts_list = new List<newsCeleb>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["Celebs_For_Tv_" + p_postsNum] != null)
            {
                posts_list = (List<newsCeleb>)i_chache["Celebs_For_Tv_" + p_postsNum];
            }
            else
            {
                posts_list = hyDB.sp_newsCeleb_GetLatestCelebs(p_postsNum).OrderBy(m => Guid.NewGuid()).ToList();
                i_chache.Add("Celebs_For_Tv_" + p_postsNum, posts_list, DateTime.Now.AddSeconds(120));
            }

            return posts_list;
        }
        //--------------------------------------------------------------------------------------------------------------








        //--------------------------------------------------------------------------------------------------------------
        public newsCeleb GetCelebByID(int p_id)
        {
            newsCeleb post = new newsCeleb();


            post = (newsCeleb)hyDB.sp_newsCelebs_GetCelebByID(p_id).FirstOrDefault();
            if (post == null)
                post = new newsCeleb();


            return post;
        }
        //----------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public void DeleteSeleb(int seleb_ID)
        {
            hyDB.sp_newsCelebs_DeleteSeleb(seleb_ID);
        }
        //--------------------------------------------------------------------------------------------------------------




    }
}
