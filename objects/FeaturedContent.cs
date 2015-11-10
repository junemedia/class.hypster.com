using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class FeaturedContent
    {

        public FeaturedContent()
        {
            _fc_active = true;
            _fc_href = "";
            _fc_ID = 0;
            _fc_image = "";
            _fc_name = "";
            _fc_type = 0;
            _fc_href_mobile = "";
        }


    }


    public enum fc_Type : int
    {
        Seasonal_Playlists = 1,
        Artist_Playlists = 2,
        Other = 0
    }


}
