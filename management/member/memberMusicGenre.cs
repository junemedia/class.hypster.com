using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class MemberMusicGenreManager
    {

        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public MemberMusicGenreManager()
        {
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        // no datacache here ( need to find out more details)
        public List<MusicGenre> GetMusicGenresList()
        {
            List<MusicGenre> genres_list = new List<MusicGenre>();

            genres_list = hyDB.sp_MusicGenre_GetMusicGenresList().ToList();
            
            return genres_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        // no datacache here ( need to find out more details)
        public List<MusicGenre> GetMusicGenresList_Random()
        {
            List<MusicGenre> genres_list = new List<MusicGenre>();

            genres_list = hyDB.sp_MusicGenre_GetMusicGenresList().OrderBy(gnr => Guid.NewGuid()).ToList();

            return genres_list;
        }
        //----------------------------------------------------------------------------------------------------------

        //----------------------------------------------------------------------------------------------------------
        // no datacache here ( need to find out more details)
        public List<MusicGenre> GetMusicGenresListPopular_Random()
        {
            List<MusicGenre> genres_list = new List<MusicGenre>();

            genres_list = hyDB.sp_MusicGenre_GetMusicGenresListPopular().OrderBy(gnr => Guid.NewGuid()).ToList();

            return genres_list;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public MusicGenre GetMusicGenre_byID(int genre_id)
        {
            MusicGenre genre = new MusicGenre();

            genre = hyDB.sp_MusicGenre_GetMusicGenre_byID(genre_id).FirstOrDefault();

            if(genre == null)
                genre = new MusicGenre();

            return genre;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void AddMusicGenre(MusicGenre genre)
        {
            hyDB.MusicGenres.AddObject(genre);
            hyDB.SaveChanges();
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void SaveMusicGenre(MusicGenre genre)
        {

            hyDB.sp_MusicGenre_SaveMusicGenre(genre.Genre_ID, genre.GenreName, genre.User_ID, genre.Playlist_ID);

        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void DeleteGenre(int genre_id)
        {
            hyDB.sp_MusicGenre_DeleteGenre(genre_id);
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<MemberMusicGenre> GetUserMusicGenres(int member_id)
        {
            List<MemberMusicGenre> genres_list = new List<MemberMusicGenre>();

            genres_list = hyDB.sp_memberMusicGenre_GetUserMusicGenres(member_id).ToList();

            return genres_list;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public void DeleteAllUserMusicGenres(int member_id)
        {
            hyDB.sp_memberMusicGenre_DeleteAllUserMusicGenres(member_id);
        }
        //----------------------------------------------------------------------------------------------------------
    }
}
