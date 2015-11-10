using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class videoClipManager
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public videoClipManager()
        {
        }
        //----------------------------------------------------------------------------------------------------------



        
        //--------------------------------------------------------------------------------------------------------------
        // need to split logic and impelemnt select with statuses
        public int getNumberOfVideoClips()
        {
            int clipsNumber = 0;

            clipsNumber = (int)hyDB.sp_videoClips_getNumberOfVideoClips().FirstOrDefault();
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

            clipsList = hyDB.sp_videoClips_getNewVideos(p_numOfVideos).ToList();

            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------




        //--------------------------------------------------------------------------------------------------------------
        public List<videoClip> getNewVideos_cache(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["NewVideos_Tv_" + p_numOfVideos] != null)
            {
                clipsList = (List<videoClip>)i_chache["NewVideos_Tv_" + p_numOfVideos];
            }
            else
            {
                clipsList = hyDB.sp_videoClips_getNewVideos(p_numOfVideos).ToList();
                i_chache.Add("NewVideos_Tv_" + p_numOfVideos, clipsList, DateTime.Now.AddSeconds(120));
            }

            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------





        
        //--------------------------------------------------------------------------------------------------------------
        // need to split logic and impelemnt select with statuses
        public List<videoClip> getTopRatedVideos(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();

            clipsList = hyDB.sp_videoClips_getTopRatedVideos(p_numOfVideos).ToList();

            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public List<videoClip> getTopRatedVideos_cache(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["TopRatedVideos_Tv_" + p_numOfVideos] != null)
            {
                clipsList = (List<videoClip>)i_chache["TopRatedVideos_Tv_" + p_numOfVideos];
            }
            else
            {
                clipsList = hyDB.sp_videoClips_getTopRatedVideos(p_numOfVideos).ToList();
                i_chache.Add("TopRatedVideos_Tv_" + p_numOfVideos, clipsList, DateTime.Now.AddSeconds(120));
            }


            return clipsList;
        }
        //--------------------------------------------------------------------------------------------------------------




        
        //--------------------------------------------------------------------------------------------------------------
        public List<videoClip> getRandomVideos_cache(int p_numOfVideos = 256)
        {
            List<videoClip> clipsList = new List<videoClip>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["RandomVideos_Tv_" + p_numOfVideos] != null)
            {
                clipsList = (List<videoClip>)i_chache["RandomVideos_Tv_" + p_numOfVideos];
            }
            else
            {
                clipsList = hyDB.sp_videoClips_getRandomVideos(p_numOfVideos).ToList();
                i_chache.Add("RandomVideos_Tv_" + p_numOfVideos, clipsList, DateTime.Now.AddSeconds(60));
            }


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
        public List<videoComment> GetVideoComments(int video_id)
        {
            List<videoComment> comments_list = new List<videoComment>();

            comments_list = hyDB.sp_videoComment_GetVideoComments(video_id).ToList();

            return comments_list;
        }
        //--------------------------------------------------------------------------------------------------------------



        //--------------------------------------------------------------------------------------------------------------
        public List<videoComment> GetVideoComments_cache(int videoClip_ID)
        {
            List<videoComment> comments_list = new List<videoComment>();


            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["VideoComment_For_Tv_" + videoClip_ID] != null)
            {
                comments_list = (List<videoComment>)i_chache["VideoComment_For_Tv_" + videoClip_ID];
            }
            else
            {
                comments_list = hyDB.sp_videoComment_GetVideoComments(videoClip_ID).ToList();
                i_chache.Add("VideoComment_For_Tv_" + videoClip_ID, comments_list, DateTime.Now.AddSeconds(120));
            }

            return comments_list;
        }
        //--------------------------------------------------------------------------------------------------------------



    }
}
