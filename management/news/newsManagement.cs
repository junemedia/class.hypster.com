using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;


namespace hypster_tv_DAL
{
    public class newsManagement
    {

        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public newsManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------




        
        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns latest (default 256 posts)
        /// </summary>
        /// <returns></returns>
        public List<newsPost> GetLatestNews(int p_post_num = 256)
        {
            List<newsPost> posts_list = new List<newsPost>();

            posts_list = hyDB.sp_newsPost_GetLatestNews(p_post_num).ToList();
            
            return posts_list;
        }
        //----------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns all news
        /// </summary>
        /// <returns></returns>
        public List<newsPost> GetAllNews()
        {
            List<newsPost> posts_list = new List<newsPost>();

            posts_list = hyDB.sp_newsPost_GetAllNews().ToList();

            return posts_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns latest 256 posts (results are cahched for 2 min)
        /// </summary>
        /// <returns></returns>
        public List<newsPost> GetLatestNews_cache(int p_postsNum = 256)
        {
            List<newsPost> posts_list = new List<newsPost>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["News_For_Tv_" + p_postsNum] != null)
            {
                posts_list = (List<newsPost>)i_chache["News_For_Tv_" + p_postsNum];
            }
            else
            {
                posts_list = hyDB.sp_newsPost_GetLatestNews(p_postsNum).ToList();
                i_chache.Add("News_For_Tv_" + p_postsNum, posts_list, DateTime.Now.AddSeconds(120));
            }

            return posts_list;
        }
        //--------------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// returns related posts (results are cahched for 2 min)
        /// </summary>
        /// <returns></returns>
        public List<newsPost> GetRelatedNews_cache(int p_post_ID)
        {
            List<newsPost> posts_list = new List<newsPost>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["Related_News_" + p_post_ID] != null)
            {
                posts_list = (List<newsPost>)i_chache["Related_News_" + p_post_ID];
            }
            else
            {
                posts_list = hyDB.sp_newsPost_GetRelatedNews(p_post_ID).ToList();
                i_chache.Add("Related_News_" + p_post_ID, posts_list, DateTime.Now.AddSeconds(120));
            }

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








        //--------------------------------------------------------------------------------------------------------------
        public List<newsComment> GetPostComments(int post_id)
        {
            List<newsComment> comments_list = new List<newsComment>();

            comments_list = hyDB.sp_newsComment_GetPostComments(post_id).ToList();

            return comments_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<newsComment> GetPostComments_cache(int post_id)
        {
            List<newsComment> comments_list = new List<newsComment>();

            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["NewsComment_For_Tv_" + post_id] != null)
            {
                comments_list = (List<newsComment>)i_chache["NewsComment_For_Tv_" + post_id];
            }
            else
            {
                comments_list = hyDB.sp_newsComment_GetPostComments(post_id).ToList();
                i_chache.Add("NewsComment_For_Tv_" + post_id, comments_list, DateTime.Now.AddSeconds(120));
            }

            return comments_list;
        }
        //--------------------------------------------------------------------------------------------------------------



    }
}
