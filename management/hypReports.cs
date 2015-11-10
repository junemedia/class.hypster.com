using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class hypReports
    {

        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public hypReports()
        {
        }


        public int Followers_NUM()
        {
            int Followers_NUM = 0;
            Followers_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(UsFol_ID) AS Followers FROM Followers ").FirstOrDefault();
            return Followers_NUM;
        }



        public int Members_NUM()
        {
            int Members_NUM = 0;
            Members_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(id) AS Members FROM Members ").FirstOrDefault();
            return Members_NUM;
        }



        public int MemberMusicGenre_NUM()
        {
            int MemberMusicGenre_NUM = 0;
            MemberMusicGenre_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(MemberMusicGenre_ID) AS MemberMusicGenre FROM MemberMusicGenre ").FirstOrDefault();
            return MemberMusicGenre_NUM;
        }



        public int Photos_NUM()
        {
            int Photos_NUM = 0;
            Photos_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(id) AS Photos FROM Photos ").FirstOrDefault();
            return Photos_NUM;
        }


        public int PlaylistLikes_NUM()
        {
            int PlaylistLikes_NUM = 0;
            PlaylistLikes_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(PlaylistLikesId) AS PlaylistLikes FROM PlaylistLikes ").FirstOrDefault();
            return PlaylistLikes_NUM;
        }


        public int Playlists_NUM()
        {
            int Playlists_NUM = 0;
            Playlists_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(id) AS Playlists FROM Playlists ").FirstOrDefault();
            return Playlists_NUM;
        }


        public int RadioStation_NUM()
        {
            int RadioStation_NUM = 0;
            RadioStation_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(RadioStation_ID) AS RadioStation FROM RadioStation ").FirstOrDefault();
            return RadioStation_NUM;
        }


        public int Songs_NUM()
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" SELECT COUNT(id) AS Songs FROM PlaylistData ").FirstOrDefault();
            return Songs_NUM;
        }

        public int Last_Song_ID()
        {
            int LAST_SONG_ID = 0;
            LAST_SONG_ID = hyDB.ExecuteStoreQuery<int>(" SELECT MAX(id) FROM [PlaylistData] ").FirstOrDefault();
            return LAST_SONG_ID;
        }







        public int SongsStarted_NUM(DateTime dt)
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" select COUNT(TrackWebsite_KeyID) from TrackWebsite WHERE TrackWebsite_KeyID = 50005 AND YEAR(TrackDate) = " + dt.Year + " AND MONTH(TrackDate) = " + dt.Month + " AND DAY(TrackDate) = " + dt.Day).FirstOrDefault();
            return Songs_NUM;
        }

        public int SongsPlayed_NUM(DateTime dt)
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" select COUNT(TrackWebsite_KeyID) from TrackWebsite WHERE TrackWebsite_KeyID = 50003 AND YEAR(TrackDate) = " + dt.Year + " AND MONTH(TrackDate) = " + dt.Month + " AND DAY(TrackDate) = " + dt.Day).FirstOrDefault();
            return Songs_NUM;
        }

        public int SongsDesktopPlayer_NUM(DateTime dt)
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" select COUNT(TrackWebsite_KeyID) from TrackWebsite WHERE TrackWebsite_KeyID = 50007 AND YEAR(TrackDate) = " + dt.Year + " AND MONTH(TrackDate) = " + dt.Month + " AND DAY(TrackDate) = " + dt.Day).FirstOrDefault();
            return Songs_NUM;
        }

        public int SongsAppsMob_NUM(DateTime dt)
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" select COUNT(TrackWebsite_KeyID) from TrackWebsite WHERE TrackWebsite_KeyID = 500013 AND YEAR(TrackDate) = " + dt.Year + " AND MONTH(TrackDate) = " + dt.Month + " AND DAY(TrackDate) = " + dt.Day).FirstOrDefault();
            return Songs_NUM;
        }

        public int SongsBreakingPlayer_NUM(DateTime dt)
        {
            int Songs_NUM = 0;
            Songs_NUM = hyDB.ExecuteStoreQuery<int>(" select COUNT(TrackWebsite_KeyID) from TrackWebsite WHERE TrackWebsite_KeyID = 500015 AND YEAR(TrackDate) = " + dt.Year + " AND MONTH(TrackDate) = " + dt.Month + " AND DAY(TrackDate) = " + dt.Day).FirstOrDefault();
            return Songs_NUM;
        }



    }
}
