using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class playlistLikeManagement
    {

        //----------------------------------------------------------------------------------------------------------
        Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public playlistLikeManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public string AddNewPlaylistLike(PlaylistLike new_like)
        {
            if (CheckPlaylistLike(new_like.PlaylistId, new_like.UserId) == false)
            {
                playlistManagement playlistManager = new playlistManagement();
                
                hyDB.PlaylistLikes.AddObject(new_like);
                hyDB.SaveChanges();

                playlistManager.AddPlaylistLike(new_like.PlaylistId);

                return "1";
            }

            return "-1";
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void DeletePlaylistLike(int playlist_id, int user_id)
        {
            hyDB.sp_playlistLike_DeletePlaylistLike(playlist_id, user_id);
        }
        //----------------------------------------------------------------------------------------------------------








        //-NI
        //----------------------------------------------------------------------------------------------------------
        public int GetPlaylistLikesNum(int playlist_id)
        {
            //int playlist_like_num = 0;
            //int plstLike = 0;
            ////plstLike = hyDB.sp_playlistLike_GetPlaylistLikesNum(playlist_id).FirstOrDefault();
            //if (plstLike != null || plstLike > 0)
            //    playlist_like_num = plstLike;
            //return playlist_like_num;
            return -1;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public bool CheckPlaylistLike(int playlist_id, int user_id)
        {
            bool isAlreadyLiked = false;


            PlaylistLike check_like = new PlaylistLike();
            check_like = hyDB.sp_playlistLike_CheckPlaylistLike(playlist_id, user_id).FirstOrDefault();

            if (check_like != null && check_like.PlaylistLikesId > 0)
                isAlreadyLiked = true;


            return isAlreadyLiked;
        }
        //----------------------------------------------------------------------------------------------------------




    }
}
