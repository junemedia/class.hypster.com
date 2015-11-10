using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class videoComment
    {
        public videoComment()
        {
            _comment = "";
            _ipAddress = "";
            _postDate = new DateTime(1900,1,1);
            _status = (int)videoCommentStatus.NoActive;
            _user_ID = 0;
            _videoClip_ID = 0;
            _videoComment_ID = 0;
            _userName = "";
        }
    }



    public enum videoCommentStatus : int
    {
        NoActive = 0,
        Active = 1
    }

}
