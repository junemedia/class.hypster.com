using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class ListenHistory
    {

        public ListenHistory()
        {
            _ListenHistory_Date = new DateTime(1900, 1, 1);
            _ListenHistory_GUID = "";
            _ListenHistory_ID = 0;
            _ListenHistory_Title = "";
            _ListenHistory_URL = "";
            _ListenHistory_UserID = 0;
        }



    }
}
