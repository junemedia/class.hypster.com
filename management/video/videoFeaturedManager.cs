using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace hypster_tv_DAL
{
    public class videoFeaturedManager
    {
        //--------------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public videoFeaturedManager()
        {
        }
        //--------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public List<videoFeaturedSlideshow> getFeaturedVideos()
        {
            List<videoFeaturedSlideshow> featuredVideos = new List<videoFeaturedSlideshow>();

            featuredVideos = hyDB.sp_videoFeatured_getFeaturedVideos().ToList();

            return featuredVideos;
        }
        //--------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public videoFeaturedSlideshow getFeaturedVideoByID(int p_videoFeatured_ID)
        {
            videoFeaturedSlideshow retVideo = new videoFeaturedSlideshow();

            retVideo = hyDB.sp_videoFeatured_getFeaturedVideoByID(p_videoFeatured_ID).FirstOrDefault();
            if (retVideo == null)
                retVideo = new videoFeaturedSlideshow();

            return retVideo;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public void DeleteFeaturedVideo(int p_videoFeatured_ID)
        {
            hyDB.sp_videoFeatured_DeleteFeaturedVideo(p_videoFeatured_ID);
        }
        //--------------------------------------------------------------------------------------------------------------

    }
}
