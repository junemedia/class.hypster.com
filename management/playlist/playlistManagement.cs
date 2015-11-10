using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class playlistManagement
    {
        //----------------------------------------------------------------------------------------------------------
        private Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public playlistManagement()
        {
            
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public int AddNewPlaylist(Playlist playlist)
        {
            hyDB.Playlists.AddObject(playlist);
            hyDB.SaveChanges();

            return playlist.id;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns list of playlists for user 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<Playlist> GetUserPlaylists(int user_id)
        {
            List<Playlist> user_playlists = new List<Playlist>();

            user_playlists = hyDB.sp_Playlist_GetUserPlaylists(user_id).ToList();

            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns list of playlist by id
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public Playlist GetUserPlaylistById(int user_id, int playlist_id)
        {
            Playlist curr_user_playlist = new Playlist();

            curr_user_playlist = hyDB.sp_Playlist_GetUserPlaylistById(user_id, playlist_id).FirstOrDefault();
            if (curr_user_playlist == null)
                curr_user_playlist = new Playlist();

            return curr_user_playlist;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns list of songs for requested playlist
        /// Object contains (Song Data) and (User Playlist Data)
        /// </summary>
        /// <param name="playlist_id"></param>
        /// <returns></returns>
        public List<PlaylistData_Song> GetSongsForPlayList(int user_id, int playlist_id)
        {
            List<PlaylistData_Song> songs_list = new List<PlaylistData_Song>();

            songs_list = hyDB.sp_Playlist_GetSongsForPlayList(playlist_id, user_id).ToList();

            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Dead Links
        /// Returns list of songs for requested playlist
        /// Object contains (Song Data) and (User Playlist Data)
        /// </summary>
        /// <param name="playlist_id"></param>
        /// <returns></returns>
        public List<sp_Playlist_GetSongsDeadLinks_Result> GetSongsForPlayListDeadLinks(int user_id, int playlist_id)
        {
            List<sp_Playlist_GetSongsDeadLinks_Result> songs_list = new List<sp_Playlist_GetSongsDeadLinks_Result>();

            songs_list = hyDB.sp_Playlist_GetSongsForPlayListDeadLinks(playlist_id, user_id).ToList();

            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns random list of songs for requested playlist
        /// Object contains (Song Data) and (User Playlist Data)
        /// </summary>
        /// <param name="playlist_id"></param>
        /// <returns></returns>
        public List<PlaylistData_Song> GetSongsForPlayList_Random(int user_id, int playlist_id)
        {
            List<PlaylistData_Song> songs_list = new List<PlaylistData_Song>();

            songs_list = hyDB.sp_Playlist_GetSongsForPlayList_Random(playlist_id, user_id).ToList();

            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns list of songs for requested playlist
        /// Object contains (Song Data) and (User Playlist Data)
        /// </summary>
        /// <param name="playlist_id"></param>
        /// <returns></returns>
        public List<PlaylistData_Song> GetPlayListDataByPlaylistID(int playlist_id)
        {
            List<PlaylistData_Song> songs_list = new List<PlaylistData_Song>();

            songs_list = hyDB.sp_Playlist_GetPlayListDataByPlaylistID(playlist_id).ToList();

            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns list of songs for requested playlist
        /// Object contains (Song Data) and (User Playlist Data)
        /// </summary>
        /// <param name="playlist_id"></param>
        /// <returns></returns>
        public List<PlaylistData_Song> GetPlayListDataByPlaylistID_Random(int playlist_id)
        {
            List<PlaylistData_Song> songs_list = new List<PlaylistData_Song>();

            songs_list = hyDB.sp_Playlist_GetPlayListDataByPlaylistID_Random(playlist_id).ToList();

            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public void Delete_Playlist(int user_id, int playlist_id)
        {
            //1st step - delete songs
            DeleteSongs(user_id, playlist_id);

            //2nd step - delete playlist
            hyDB.sp_Playlist_Delete_Playlist(user_id, playlist_id);
            
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void Edit_Playlist(int user_id, int playlist_id, string playlist_name)
        {
            hyDB.sp_Playlist_Edit_Playlist(user_id, playlist_id, playlist_name);
        }
        //----------------------------------------------------------------------------------------------------------



        // ++++
        //--------------------------------------------------------------------------------------------------------------
        public void AddPlaylistView(int? p_playlist_ID)
        {
            hyDB.sp_Playlist_AddPlaylistView(p_playlist_ID);
        }
        //--------------------------------------------------------------------------------------------------------------


        // ++++
        //--------------------------------------------------------------------------------------------------------------
        public void AddPlaylistLike(int? p_playlist_ID)
        {
            hyDB.sp_Playlist_AddPlaylistLike(p_playlist_ID);
        }
        //--------------------------------------------------------------------------------------------------------------




        // ++++
        //--------------------------------------------------------------------------------------------------------------
        public void UpdatePlaylistShares(int? p_playlist_ID, int? p_user_id, int p_shares_num)
        {
            hyDB.sp_Playlist_UpdatePlaylistShares(p_playlist_ID, p_user_id, p_shares_num);
        }
        //--------------------------------------------------------------------------------------------------------------



        // ++++
        //--------------------------------------------------------------------------------------------------------------
        public void UpdatePlaylistDesc(int p_playlist_ID, string p_playlist_Desc)
        {
            hyDB.sp_Playlist_UpdatePlaylistDesc(p_playlist_ID, p_playlist_Desc);
        }
        //--------------------------------------------------------------------------------------------------------------








        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Update Order for all playlist
        /// </summary>
        /// <param name="p_user_id"></param>
        /// <param name="songs_arr"></param>
        /// <returns></returns>
        public bool Update_CustomOrder(int p_user_id, List<PlaylistData_Song> songs_arr)
        {
            bool _add_res = false;



            foreach (PlaylistData_Song item in songs_arr)
            {
                EditPlaylistSongOrder(p_user_id, item.playlist_track_id, item.sortid);
            }
            _add_res = true;
            


            return _add_res;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Edit Playlist Order
        /// </summary>
        /// <param name="p_user_id"></param>
        /// <param name="song_id"></param>
        /// <param name="sortid"></param>
        public void EditPlaylistSongOrder(int p_user_id, int song_id, short sortid)
        {
            hyDB.sp_Playlist_EditPlaylistSongOrder(p_user_id, song_id, sortid);
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Edit Playlist Order
        /// </summary>
        /// <param name="p_user_id"></param>
        /// <param name="song_id"></param>
        /// <param name="sortid"></param>
        public void IncrementPlaylistSongOrder(int p_user_id, int p_playlist_id)
        {
            hyDB.sp_Playlist_IncrementPlaylistSongOrder(p_user_id, p_playlist_id);
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete songs for all playlist
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="playlist_id"></param>
        public void DeleteSongs(int user_id, int playlist_id)
        {
            hyDB.sp_Playlist_DeleteSongs(user_id, playlist_id);
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Delete specific song
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="song_id"></param>
        public void DeleteSong(int user_id, int song_id)
        {
            hyDB.sp_Playlist_DeleteSong(user_id, song_id);
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetMostViewedPlaylists()
        {
            List<Playlist> user_playlists = new List<Playlist>();


            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetMostViewedPlaylists"] != null)
            {
                user_playlists = (List<Playlist>)i_chache["GetMostViewedPlaylists"];
            }
            else
            {
                user_playlists = hyDB.sp_Playlist_GetMostViewedPlaylists().OrderBy(plst => Guid.NewGuid()).ToList();
                i_chache.Add("GetMostViewedPlaylists", user_playlists, DateTime.Now.AddSeconds(9000)); //15 mins
            }
            
            


            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetMostViewedPlaylistsAdmin()
        {
            List<Playlist> user_playlists = new List<Playlist>();

            user_playlists = hyDB.sp_Playlist_GetMostViewedPlaylistsAdmin().ToList();
            
            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetMostLikedPlaylists()
        {
            List<Playlist> user_playlists = new List<Playlist>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetMostLikedPlaylists"] != null)
            {
                user_playlists = (List<Playlist>)i_chache["GetMostLikedPlaylists"];
            }
            else
            {
                user_playlists = hyDB.sp_Playlist_GetMostLikedPlaylists().ToList();
                i_chache.Add("GetMostLikedPlaylists", user_playlists, DateTime.Now.AddSeconds(9000)); //15 mins
            }


            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetMostLikedPlaylistsRandom()
        {
            List<Playlist> user_playlists = new List<Playlist>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetMostLikedPlaylists"] != null)
            {
                user_playlists = (List<Playlist>)i_chache["GetMostLikedPlaylists"];
            }
            else
            {
                user_playlists = hyDB.sp_Playlist_GetMostLikedPlaylists().OrderBy(plst => Guid.NewGuid()).ToList();
                i_chache.Add("GetMostLikedPlaylists", user_playlists, DateTime.Now.AddSeconds(9000)); //15 mins
            }


            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetMostLikedPlaylistsAdmin()
        {
            List<Playlist> user_playlists = new List<Playlist>();

            user_playlists = hyDB.sp_Playlist_GetMostLikedPlaylistsAdmin().ToList();
            
            
            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetNewPlaylists()
        {
            List<Playlist> user_playlists = new List<Playlist>();


            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetNewPlaylists"] != null)
            {
                user_playlists = (List<Playlist>)i_chache["GetNewPlaylists"];
            }
            else
            {
                user_playlists = hyDB.sp_Playlist_GetNewPlaylists().OrderBy(plst => Guid.NewGuid()).ToList();
                i_chache.Add("GetNewPlaylists", user_playlists, DateTime.Now.AddSeconds(9000)); //15 mins
            }


            return user_playlists;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetPlaylistsILike(int user_id)
        {
            List<Playlist> user_liked_playlists = new List<Playlist>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetPlaylistsILike" + user_id] != null)
            {
                user_liked_playlists = (List<Playlist>)i_chache["GetPlaylistsILike" + user_id];
            }
            else
            {
                user_liked_playlists = hyDB.sp_Playlist_GetPlaylistsILike(user_id).OrderBy(plst => Guid.NewGuid()).ToList();
                i_chache.Add("GetPlaylistsILike" + user_id, user_liked_playlists, DateTime.Now.AddSeconds(60)); //1 mins
            }


            return user_liked_playlists;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetPlaylistsILike_NoCache(int user_id)
        {
            List<Playlist> user_liked_playlists = new List<Playlist>();

            user_liked_playlists = hyDB.sp_Playlist_GetPlaylistsILike(user_id).OrderBy(plst => Guid.NewGuid()).ToList();
            
            return user_liked_playlists;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public List<Playlist> GetWithDescPlaylists()
        {
            List<Playlist> model = new List<Playlist>();

            model = hyDB.sp_Playlist_GetWithDescPlaylists().ToList();

            return model;
        }
        //----------------------------------------------------------------------------------------------------------





        public List<Playlist> SearchPlaylistByDesc(string search_term)
        {
            List<Playlist> model = new List<Playlist>();

            model = hyDB.sp_Playlist_SearchPlaylistByDesc(search_term).ToList();

            return model;
        }




    }
}
