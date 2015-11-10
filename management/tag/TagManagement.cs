using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class TagManagement
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public TagManagement()
        {
        }
        //--------------------------------------------------------------------------------------------------------------





        public void IncrementPopularTag(int tag_id)
        {
            hyDB.sp_Tag_IncrementPopularTag(tag_id);
        }




        //--------------------------------------------------------------------------------------------------------------
        public List<Playlist> GetPlaylistsByTagId(int tag_id)
        {
            List<Playlist> playlists_list = new List<Playlist>();


            playlists_list = hyDB.sp_Tag_GetPlaylistsByTagId(tag_id).ToList();

            if (playlists_list == null)
            {
                playlists_list = new List<Playlist>();
            }

            return playlists_list;
        }
        //--------------------------------------------------------------------------------------------------------------






        //--------------------------------------------------------------------------------------------------------------
        public List<newsPost> GetNewsByTagId(int tag_id)
        {
            List<newsPost> news_list = new List<newsPost>();


            news_list = hyDB.sp_Tag_GetNewsByTagId(tag_id).ToList();

            if (news_list == null)
            {
                news_list = new List<newsPost>();
            }

            return news_list;
        }
        //--------------------------------------------------------------------------------------------------------------




        public List<Tag> SearchTags(string p_ss)
        {
            List<Tag> tags_list = new List<Tag>();

            tags_list = hyDB.sp_Tag_SearchTags(p_ss).ToList();

            if (tags_list == null)
            {
                tags_list = new List<Tag>();
            }

            return tags_list;
        }




        //--------------------------------------------------------------------------------------------------------------
        public Tag GetTagByName(string tag_name)
        {
            Tag tag = new Tag();

            tag = hyDB.sp_Tag_GetTagByName(tag_name).FirstOrDefault();

            if (tag == null)
            {
                tag = new Tag();
            }


            return tag;
        }
        //--------------------------------------------------------------------------------------------------------------





        //--------------------------------------------------------------------------------------------------------------
        public List<Tag> GetPopularTags()
        {
            List<Tag> tags_list = new List<Tag>();

            tags_list = hyDB.sp_Tag_GetPopularTags().ToList();

            if (tags_list == null)
            {
                tags_list = new List<Tag>();
            }

            return tags_list;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public List<sp_Tag_GetPopularNewsTags_Result> GetPopularNewsTags()
        {
            List<sp_Tag_GetPopularNewsTags_Result> tags_list = new List<sp_Tag_GetPopularNewsTags_Result>();

            tags_list = hyDB.sp_Tag_GetPopularNewsTags().ToList();

            if (tags_list == null)
            {
                tags_list = new List<sp_Tag_GetPopularNewsTags_Result>();
            }

            return tags_list;
        }
        //--------------------------------------------------------------------------------------------------------------






        //--------------------------------------------------------------------------------------------------------------
        public List<sp_Tag_GetPlaylistTags_Result> GetPlaylistTags(int playlist_id)
        {
            List<sp_Tag_GetPlaylistTags_Result> tags_list = new List<sp_Tag_GetPlaylistTags_Result>();

            tags_list = hyDB.sp_Tag_GetPlaylistTags(playlist_id).ToList();

            if (tags_list == null)
            {
                tags_list = new List<sp_Tag_GetPlaylistTags_Result>();
            }

            return tags_list;
        }
        //--------------------------------------------------------------------------------------------------------------







        //--------------------------------------------------------------------------------------------------------------
        public int AddNewTag(string tag_name)
        {
            int new_id = 0;

            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("p_new_id", typeof(int));

            hyDB.sp_Tag_AddNewTag(tag_name, 0, 0, 0, param);

            new_id = (int)param.Value;

            return new_id;
        }
        //--------------------------------------------------------------------------------------------------------------







        //--------------------------------------------------------------------------------------------------------------
        public int AddTagToPlaylist(int tag_id, int playlist_id)
        {
            Tag_Playlist new_add = new Tag_Playlist();
            new_add.Playlist_ID = playlist_id;
            new_add.Tag_ID = tag_id;

            hyDB.Tag_Playlist.AddObject(new_add);
            hyDB.SaveChanges();


            return new_add.Tag_Playlist_ID;
        }
        //--------------------------------------------------------------------------------------------------------------





        
        // add new tag to atricle
        //
        //--------------------------------------------------------------------------------------------------------------
        public int AddTagToNewsArticle(int tag_id, int article_id)
        {
            Tag_News new_add = new Tag_News();
            new_add.Article_ID = article_id;
            new_add.Tag_ID = tag_id;

            hyDB.Tag_News.AddObject(new_add);
            hyDB.SaveChanges();


            return new_add.Tag_News_ID;
        }
        //--------------------------------------------------------------------------------------------------------------





        //--------------------------------------------------------------------------------------------------------------
        public List<sp_Tag_GetNewsTags_Result> GetNewsTags(int article_id)
        {
            List<sp_Tag_GetNewsTags_Result> tags_list = new List<sp_Tag_GetNewsTags_Result>();

            
            tags_list = hyDB.sp_Tag_GetNewsTags(article_id).ToList();

            if (tags_list == null)
            {
                tags_list = new List<sp_Tag_GetNewsTags_Result>();
            }
            

            return tags_list;
        }
        //--------------------------------------------------------------------------------------------------------------















        //--------------------------------------------------------------------------------------------------------------
        public void DeletePlaylistTag(int plst_tag_id)
        {
            hyDB.sp_Tag_DeletePlaylistTag(plst_tag_id);
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public void DeleteNewsTag(int news_tag_id)
        {
            hyDB.sp_Tag_DeleteNewsTag(news_tag_id);
        }
        //--------------------------------------------------------------------------------------------------------------


    }

}
