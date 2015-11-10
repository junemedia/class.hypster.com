using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class memberPhotoManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public memberPhotoManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public int AddUserPhoto(int user_id, string caption)
        {
            int new_id = 0;

            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("p_new_id", typeof(int));
            
            hyDB.sp_Photo_AddUserPhoto(user_id, caption, param);

            new_id = (int)param.Value;

            return new_id;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public List<Photo> GetUserPhotos(int user_id)
        {
            List<Photo> photos_list = new List<Photo>();

            photos_list = hyDB.sp_Photo_GetUserPhotos(user_id).ToList();

            return photos_list;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void DeleteUserPhoto(int photo_id, int user_id)
        {
            hyDB.sp_Photo_DeleteUserPhoto(photo_id, user_id);
        }
        //----------------------------------------------------------------------------------------------------------



    }
}
