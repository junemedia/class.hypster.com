using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class Player
    {
        public Player()
        {
            _BAR_autostart = false;
            _BAR_placementOfThePlayer = "bottom";
            _BAR_showPlaylistByDefault = false;
            _BAR_shufflePlayback = false;
            _BAR_playerSkin = "";

            _CLASSIC_autostart = false;
            _CLASSIC_playerSkin = "";
            _CLASSIC_shufflePlayback = false;

            _RADIO_autostart = false;
            _RADIO_Genre = "";
            _RADIO_Genre_ID = 0;


            _player_ID = 0;
            _player_Name = "";
            _playlist_ID = 0;
            _Player_Type = "";
            _user_ID = 0;
        }

    }
}
