using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class CoverContestVote
    {
        public CoverContestVote()
        {
            _CoverContestVote_Cover_ID = 0;
            _CoverContestVote_DateAdded = new DateTime(1900, 1, 1);
            _CoverContestVote_ID = 0;
            _CoverContestVote_IP = "";
        }
    }
}
