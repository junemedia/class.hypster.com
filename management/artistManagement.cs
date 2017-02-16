using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class artistManagement
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public artistManagement()
        {
            
        }



        public ArtistCategory GetArtistByName(string artist_name)
        {
            ArtistCategory curr_artist = new ArtistCategory();

            curr_artist = (ArtistCategory)hyDB.sp_artist_GetArtistByName(artist_name).FirstOrDefault();
            if (curr_artist == null)
            {
                curr_artist = new ArtistCategory();
            }

            return curr_artist;
        }



        
        public List<ArtistCategory> GetAllArtists()
        {
            List<ArtistCategory> artists_list = new List<ArtistCategory>();

            artists_list = hyDB.sp_artist_GetAllArtists().ToList();

            return artists_list;
        }


        public List<ArtistCategory> GetTopNotConfirmedArtists()
        {
            List<ArtistCategory> artists_list = new List<ArtistCategory>();

            artists_list = hyDB.sp_artist_GetTopNotConfirmedArtists().ToList();

            return artists_list;
        }



        public void ConfirmArtist(int p_ar_id)
        {
            hyDB.sp_artist_ConfirmArtist(p_ar_id);
        }





        public List<ArtistCategory> SearchForArtist(string p_ss)
        {
            List<ArtistCategory> artists_list = new List<ArtistCategory>();

            artists_list = hyDB.sp_artist_SearchForArtist(p_ss).ToList();

            return artists_list;
        }

        public List<sp_artistaz_GetArtistsList_Result> GetArtistsAZList_Result()        
        {
            List<sp_artistaz_GetArtistsList_Result> artists = new List<sp_artistaz_GetArtistsList_Result>();

            artists = hyDB.sp_artistaz_GetArtistsList().ToList();

            return artists;
        }

        public List<ArtistAZ> GetArtistsAZList()
        {
            int artist_result = GetArtistsAZList_Result().Count;
            List<ArtistAZ> artists = new List<ArtistAZ>();
            for (int i = 0; i < artist_result; i++)
            {
                ArtistAZ artist = new ArtistAZ();
                artist.ArtistAZ_ID = GetArtistsAZList_Result()[i].ArtistAZ_ID;
                artist.ArtistAZ_Name = GetArtistsAZList_Result()[i].ArtistAZ_Name;
                artists.Add(artist);
            }
            return artists;
        }
    }
}
