using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class Playlist
    {
        
        public Playlist()
        {
            _create_time = 0;
            _id = 0;
            _is_artist_playlist = false;
            _name = "";
            _update_time = 0;
            _userid = 0;
            _ViewsNum = 0;
            _Likes = 0;
            _username = "";
            _description = "";
            _Shares = 0;
        }


    }
}
