using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class videoClip
    {
        public videoClip()
        {
            _Description = "";
            _DownVotes = 0;
            _Duration = 0;
            _Name = "";
            _UploadDate = new DateTime(1900,1,1);
            _UploadedBy = 0;
            _UploadedByName = "";
            _UpVotes = 0;
            _videoClip_ID = 0;
            _ViewsNum = 0;
            _Status = 0;
        }
    }


    public enum VideoStatus : int
    {
        NoActive = 0,
        Active = 1
    }

}
