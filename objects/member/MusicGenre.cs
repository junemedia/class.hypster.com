using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class MusicGenre
    {
        public bool selected = false;

        public MusicGenre()
        {
            _Genre_ID = 0;
            _GenreName = "";

            _Playlist_ID = 0;
            _User_ID = 0;
        }


    }
}
