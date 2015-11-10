using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{

    public partial class Radio_Usage
    {
        public Radio_Usage()
        {
            _MIX_ID = 0;
            _PLAY_TOKEN = 0;
            _Radio_Usage_Date = new DateTime(1900,1,1);
            _Radio_Usage_ID = 0;
            _TRACK_ID = 0;
        }
    }

}
