using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class FeaturedPlaylist_Result
    {
        public FeaturedPlaylist_Result()
        {
            _FeaturedPlaylist_CreateDate = new DateTime(1900, 1, 1);
            _FeaturedPlaylist_ID = 0;
            _FeaturedPlaylist_PlaylistID = 0;
            _FeaturedPlaylist_PlaylistName = "";
            _FeaturedPlaylist_UserID = 0;

            _Likes = 0;
            _ViewsNum = 0;
        }
    }
}
