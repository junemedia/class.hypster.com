using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class FeaturedPlaylist
    {

        public FeaturedPlaylist()
        {
            _FeaturedPlaylist_CreateDate = new DateTime(1900, 1, 1);
            _FeaturedPlaylist_ID = 0;
            _FeaturedPlaylist_PlaylistID = 0;
            _FeaturedPlaylist_PlaylistName = "";
            _FeaturedPlaylist_UserID = 0;
            _FeaturedPlaylist_Guid = "";
            
        }

    }
}
