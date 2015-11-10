using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class playerManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public playerManagement()
        {   
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public List<Player> GetUserPlayersList(int user_id)
        {
            List<Player> players_list = new List<Player>();

            players_list = hyDB.sp_Player_GetUserPlayersList(user_id).ToList();
           

            return players_list;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public Player GetPlayerByID(int user_id, int player_id)
        {
            Player player = new Player();

            player = hyDB.sp_Player_GetPlayerByID(user_id, player_id).FirstOrDefault();
            if (player == null)
                player = new Player();

            return player;
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public void EditPlayer(hypster_tv_DAL.Player player)
        {
            hyDB.sp_Player_EditPlayer(player.user_ID, player.player_ID, player.player_Name, player.playlist_ID, player.BAR_autostart, player.BAR_shufflePlayback, player.BAR_placementOfThePlayer, player.BAR_showPlaylistByDefault, player.BAR_playerSkin, player.CLASSIC_autostart, player.CLASSIC_shufflePlayback, player.CLASSIC_playerSkin, player.RADIO_autostart, player.RADIO_Genre, player.RADIO_Genre_ID);
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public void DeletePlayer(int user_id, int player_id)
        {
            hyDB.sp_Player_DeletePlayer(user_id, player_id);
        }
        //----------------------------------------------------------------------------------------------------------


    }
}
