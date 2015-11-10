using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class CoverContest
    {

        public CoverContest()
        {
            _CoverContest_DateAdded = new DateTime(1900, 1, 1);
            _CoverContest_ID = 0;
            _CoverContest_NumVotes = 0;
            _CoverContest_SongID = "";
            _CoverContest_Title = "";
        }




    }
}
