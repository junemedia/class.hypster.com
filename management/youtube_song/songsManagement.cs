using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class songsManagement
    {
        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public songsManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public Song GetSongByID(string song_guid)
        {
            Song song = new Song();

            song = (Song)hyDB.sp_Song_GetSongByID(song_guid).FirstOrDefault();
            if (song == null)
                song = new Song();

            return song;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        /*
        public Song GetSongByGUID(string song_guid)
        {
            Song song = new Song();

            song = (Song)hyDB.sp_Song_GetSongByGUID(song_guid).FirstOrDefault();
            if (song == null)
                song = new Song();

            return song;
        }
        */

        public Song GetSongByGUID(string song_guid)
        {
            Song song = new Song();

            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetSongByGUID_" + song_guid] != null)
            {
                song = (Song)i_chache["GetSongByGUID_" + song_guid];
            }
            else
            {
                song = (Song)hyDB.sp_Song_GetSongByGUID(song_guid).FirstOrDefault();
                if (song != null && song.id > 0)
                {
                    i_chache.Add("GetSongByGUID_" + song_guid, song, DateTime.Now.AddHours(5));
                }
                else
                {
                    song = new Song();
                }
            }


            return song;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Song> Get_MostPopularSong_Random()
        {
            List<Song> songs_list = new List<Song>();

            

            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["Get_MostPopularSong_Random"] != null)
            {
                songs_list = (List<Song>)i_chache["Get_MostPopularSong_Random"];
            }
            else
            {
                songs_list = hyDB.sp_Songs_Get_MostPopularSong_Random().ToList();
                i_chache.Add("Get_MostPopularSong_Random", songs_list, DateTime.Now.AddHours(5));
            }


            return songs_list;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<songComment> Get_SongComments(int song_id)
        {
            List<songComment> comments_list = new List<songComment>();

            comments_list = hyDB.sp_Songs_Get_SongComments(song_id).ToList();

            return comments_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void MarkDeadLink(int song_id)
        {
            hyDB.sp_Songs_Get_MarkDeadLink(song_id);
        }
        //----------------------------------------------------------------------------------------------------------



    }
}
