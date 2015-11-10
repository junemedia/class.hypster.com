using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;


namespace hypster_tv_DAL
{
    public class newsManagement_Admin
    {
        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public newsManagement_Admin()
        {
        }
        //----------------------------------------------------------------------------------------------------------



        
        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns latest 256 posts
        /// </summary>
        /// <returns></returns>
        public List<newsPost> GetLatestNews()
        {
            List<newsPost> posts_list = new List<newsPost>();

            posts_list = hyDB.ExecuteStoreQuery<newsPost>(" SELECT TOP 256 * FROM newsPost ORDER BY post_id DESC ").ToList();

            return posts_list;
        }
        //--------------------------------------------------------------------------------------------------------------









        //--------------------------------------------------------------------------------------------------------------
        public newsPost GetPostByID(int p_id)
        {
            newsPost post = new newsPost();

            post = (newsPost)hyDB.sp_newsPost_GetPostByID(p_id).FirstOrDefault();
            if(post == null)
                post = new newsPost();

            return post;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public newsPost GetPostByGUID(string p_post_guid)
        {
            newsPost post = new newsPost();

            post = (newsPost)hyDB.sp_newsPost_GetPostByGUID(p_post_guid).FirstOrDefault();
            if(post == null)
                post = new newsPost();

            return post;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public void EditPost(newsPost p_post)
        {
            hyDB.sp_newsPost_EditPost(p_post.post_id, p_post.post_title, p_post.post_content, p_post.post_image, p_post.post_status, p_post.post_short_content, p_post.MusicPlayer, p_post.post_date);
        }
        //--------------------------------------------------------------------------------------------------------------


        public void SetPostAdID(newsPost p_post)
        {
            hyDB.sp_newsPost_SetPostAdID(p_post.post_id, p_post.ad_id);
        }


    }
}
