using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class homeSlideshowManager
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public homeSlideshowManager()
        {
        }
        //--------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public List<homeSlideshow> getHomeSlideshow()
        {
            List<homeSlideshow> slideshow_list = new List<homeSlideshow>();

            slideshow_list = hyDB.sp_homeSlideshow_getHomeSlideshow().ToList();

            return slideshow_list;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public List<homeSlideshow> getHomeSlideshowActive()
        {
            List<homeSlideshow> slideshow_list = new List<homeSlideshow>();

            slideshow_list = hyDB.sp_homeSlideshow_getHomeSlideshowActive().ToList();

            return slideshow_list;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public List<homeSlideshow> getFeaturedSlideshowActive()
        {
            List<homeSlideshow> slideshow_list = new List<homeSlideshow>();

            slideshow_list = hyDB.sp_homeSlideshow_getFeaturedSlideshowActive().ToList();

            return slideshow_list;
        }
        //--------------------------------------------------------------------------------------------------------------







        //--------------------------------------------------------------------------------------------------------------
        public homeSlideshow homeSlideshowByID(int p_homeSlideshow_ID)
        {
            homeSlideshow slideshow = new homeSlideshow();

            slideshow = hyDB.sp_homeSlideshow_homeSlideshowByID(p_homeSlideshow_ID).FirstOrDefault();
            if (slideshow == null)
                slideshow = new homeSlideshow();

            return slideshow;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public void DeleteHomeSlideshow(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_DeleteHomeSlideshow(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------------------------------------
        public void DeactivateHomeSlideshow(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_DeactivateHomeSlideshow(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------
        


        //--------------------------------------------------------------------------------------------------------------
        public void ActivateHomeSlideshow(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_ActivateHomeSlideshow(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------





        //--------------------------------------------------------------------------------------------------------------
        public void DeleteFeaturedSlideshow(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_DeleteFeaturedSlideshow(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------
        public void AddFeaturedSlideshow(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_AddFeaturedSlideshow(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------










        //--------------------------------------------------------------------------------------------------------------
        public void MoveSlideUp(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_MoveSlideUp(p_homeSlideshow_ID);
        }

        public void MoveSlideDown(int p_homeSlideshow_ID)
        {
            hyDB.sp_homeSlideshow_MoveSlideDown(p_homeSlideshow_ID);
        }
        //--------------------------------------------------------------------------------------------------------------



        public void IncAllSlides()
        {
            hyDB.sp_homeSlideshow_IncAllSlides();
        }

        public void UpdateSortOrder(int slide_ID, int order_ID)
        {
            hyDB.sp_homeSlideshow_UpdateSortOrder(slide_ID, order_ID);
        }




        public void ResetSortOrder()
        {
            List<homeSlideshow> slideshow_list = new List<homeSlideshow>();

            slideshow_list = getHomeSlideshow();

            int i_counter = 1;
            foreach (var item in slideshow_list)
            {
                UpdateSortOrder(item.homeSlideshow_ID, i_counter);
                i_counter += 1;
            }
        }



    }
}
