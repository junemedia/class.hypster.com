using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class PlaylistData_Song
    {

        public PlaylistData_Song()
        {
            //playlist data
            _playlist_track_id = 0;


            //song data
            _adddate = new DateTime(1900, 1, 1);
            _Artist = "";
            _artist_track_id = 0;
            _copyright = 0;
            _fileid = 0;
            _FullTitle = "";
            _id = 0;
            _like_count = 0;
            _songurl = "";
            _StrippedTitle = "";
            _Title = "";
            _trackcount = 0;
            _UploaderId = 0;
            _YoutubeId = "";
            _YoutubeProcessed = false;
            
        }


    }
}
