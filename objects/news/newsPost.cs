using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{

    public partial class newsPost
    {
        public newsPost()
        {
            _comment_count = 0;
            _post_author = 0;
            _post_content = "";
            _post_date = new DateTime(1900,1,1);
            _post_guid = "";
            _post_id = 0;
            _post_image = "";
            _post_status = 0;
            _post_title = "";
            _post_type = 0;
            _post_voteDown = 0;
            _post_voteUp = 0;
            _post_short_content = "";

            _MusicPlayer = "";

            _ad_id = "";
        }
    }



    public enum postStatus : int
    {
        NoActive = 0,
        Active = 1
    }


}
