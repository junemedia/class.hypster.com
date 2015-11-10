using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class manualManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public manualManagement()
        {
        }


        public void AddNewManual(Manual p_manual)
        {
            hyDB.Manuals.AddObject(p_manual);
            hyDB.SaveChanges();
        }

        public void AddNewManualSlide(Manual_Slide p_manualSlide)
        {
            hyDB.Manual_Slide.AddObject(p_manualSlide);
            hyDB.SaveChanges();
        }



        public List<Manual> GetAllManuals()
        {
            List<Manual> manuals_list = new List<Manual>();

            manuals_list = hyDB.sp_Manual_GetAllManuals().ToList();

            return manuals_list;
        }



        public List<Manual> GetActiveManuals()
        {
            List<Manual> manuals_list = new List<Manual>();

            manuals_list = hyDB.sp_Manual_GetActiveManuals().ToList();

            return manuals_list;
        }


        public Manual GetManualByGuid(string p_guid)
        {
            Manual manual = new Manual();


            manual = hyDB.sp_Manual_GetManualByGuid(p_guid).FirstOrDefault();
            if (manual == null)
                manual = new Manual();


            return manual;
        }


        public Manual GetManualByID(int id)
        {
            Manual manual = new Manual();


            manual = hyDB.sp_Manual_GetManualByID(id).FirstOrDefault();
            if (manual == null)
                manual = new Manual();


            return manual;
        }


        public void UpdateManual(Manual manual)
        {
            hyDB.sp_Manual_UpdateManual(manual.Manual_ID, manual.Manual_Active);
        }











        public List<Manual_Slide> GetManualSlides(int p_manualID)
        {
            List<Manual_Slide> slides_list = new List<Manual_Slide>();

            slides_list = hyDB.sp_Manual_GetManualSlides(p_manualID.ToString()).ToList();

            return slides_list;
        }


        public void DeleteSlide(int slide_id)
        {
            hyDB.sp_Manual_DeleteSlide(slide_id);
        }


        public void UpdateSlide(Manual_Slide manual_slide)
        {
            hyDB.sp_Manual_UpdateSlide(manual_slide.Manual_Slide_ID, manual_slide.Manual_Slide_Header, manual_slide.Manual_Slide_SortOrder, manual_slide.Manual_Slide_Active);
        }




    }

}
