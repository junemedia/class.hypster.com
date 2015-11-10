using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class FeaturedPlaylistManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------

        public FeaturedPlaylistManagement()
        {
        }


        /*
        public List<FeaturedPlaylist> ReturnFeaturedPlaylists()
        {
            List<FeaturedPlaylist> plsts_list = new List<FeaturedPlaylist>();
            plsts_list = hyDB.sp_FeaturedPlaylist_ReturnFeaturedPlaylists().ToList();
            return plsts_list;
        }*/



        
        public List<FeaturedPlaylist_Result> ReturnFeaturedPlaylists()
        {
            List<FeaturedPlaylist_Result> plsts_list = new List<FeaturedPlaylist_Result>();

            plsts_list = hyDB.sp_FeaturedPlaylist_ReturnFeaturedPlaylists().ToList();

            return plsts_list;
        }




        public void DeleteFeaturedPlaylists(int fplst_id)
        {
            hyDB.sp_FeaturedPlaylist_DeleteFeaturedPlaylists(fplst_id);
        }




        public FeaturedPlaylist_Result FeaturedPlaylistByGuid(string p_guid)
        {
            FeaturedPlaylist_Result feat_playlist = new FeaturedPlaylist_Result();

            feat_playlist = hyDB.sp_FeaturedPlaylist_FeaturedPlaylistByGuid(p_guid).FirstOrDefault();
            if (feat_playlist == null)
                feat_playlist = new FeaturedPlaylist_Result();


            return feat_playlist;
        }





    }
}
