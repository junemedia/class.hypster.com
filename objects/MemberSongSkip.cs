using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class MemberSongSkip
    {

        public MemberSongSkip()
        {
            _SongSkip_Date = new DateTime(1900, 1, 1);
            _SongSkip_ID = 0;
            _SongSkip_SongGuid = "";
            _SongSkip_SongID = 0;
            _SongSkip_UserID = 0;
        }


    }
}
