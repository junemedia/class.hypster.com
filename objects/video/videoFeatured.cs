using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace hypster_tv_DAL
{
    
    public partial class videoFeatured
    {
      
        public videoFeatured()
        {
            _ImageSrc = "";
            _SortOrder = 0;
            _videoClip_ID = 0;
            _videoFeatured_ID = 0;
        }
    }
}
