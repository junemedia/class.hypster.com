using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class newsComment
    {

        public newsComment()
        {
            _comment = "";
            _ipAddress = "";
            _newsComment_ID = 0;
            _newsPost_ID = 0;
            _status = (int)newsCommentStatus.NoActive;
            _user_ID = 0;
            _postDate = new DateTime(1900,1,1);
            _userName = "";
        }


    }


    public enum newsCommentStatus : int
    {
        NoActive = 0,
        Active = 1
    }

}
