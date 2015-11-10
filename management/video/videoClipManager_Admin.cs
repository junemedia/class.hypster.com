using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class videoClipManager_Admin
    {
        //--------------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //--------------------------------------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------------------------------------
        public videoClipManager_Admin()
        {
        }
        //--------------------------------------------------------------------------------------------------------------



        
        //--------------------------------------------------------------------------------------------------------------
        // need to split logic and impelemnt select with statuses
        public int getNumberOfVideoClips()
        {
            int clipsNumber = 0;

            clipsNumber = (int)hyDB.sp_videoClips_getNumberOfVideoClips_Admin().FirstOrDefault();
            if (clipsNumber == null)
                clipsNumber = 0;

            return clipsNumber;
        }
        //--------------------------------------------------------------------------------------------------------------





        
        //--------------------------------------------------------------------------------------------------------------
        // need to split logic and impelemnt select with statuses
        public List<videoClip> getNewVideos(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();

            clipsList = hyDB.sp_videoClips_getNewVideos_Admin(p_numOfVideos).ToList();

            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------





        
        //--------------------------------------------------------------------------------------------------------------
        // need to split logic and impelemnt select with statuses
        public List<videoClip> getTopRatedVideos(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();

            clipsList = hyDB.sp_videoClips_getTopRatedVideos_Admin(p_numOfVideos).ToList();

            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------








        //--------------------------------------------------------------------------------------------------------------
        public videoClip getVideoByGUID(string p_GUID)
        {
            videoClip retVideo = new videoClip();

            retVideo = hyDB.sp_videoClip_getVideoByGUID(p_GUID).FirstOrDefault();
            if (retVideo == null)
                retVideo = new videoClip();

            return retVideo;
        }
        //--------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public void AddVideoView(int? p_videoClip_ID, int? p_ViewsNum)
        {
            hyDB.sp_videoClips_AddVideoView(p_videoClip_ID, p_ViewsNum);
        }
        //--------------------------------------------------------------------------------------------------------------





        //--------------------------------------------------------------------------------------------------------------
        public void EditVideo(videoClip p_videoClip)
        {
            hyDB.sp_videoClips_EditVideo(p_videoClip.videoClip_ID, p_videoClip.Name, p_videoClip.Description, p_videoClip.Duration, p_videoClip.Status, p_videoClip.UploadedByName);
        }
        //--------------------------------------------------------------------------------------------------------------

    }
}
