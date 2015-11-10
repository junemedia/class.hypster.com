using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
 
    public class followersManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public followersManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public int GetNumberOfMyFollowers(int p_user_id)
        {
            int NumberOfMyFollowers = 0;

            NumberOfMyFollowers = (int)hyDB.sp_Followers_GetNumberOfMyFollowers(p_user_id).FirstOrDefault();
            if (NumberOfMyFollowers == null)
                NumberOfMyFollowers = 0;

            return NumberOfMyFollowers;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public int GetNumberOfMembersIFollow(int p_user_id)
        {
            int NumberOfMembersIFollow = 0;

            NumberOfMembersIFollow = (int)hyDB.sp_Followers_GetNumberOfMembersIFollow(p_user_id).FirstOrDefault();
            if (NumberOfMembersIFollow == null)
                NumberOfMembersIFollow = 0;

            return NumberOfMembersIFollow;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<Member> GetMyFollowers(int p_user_id)
        {
            List<Member> members = new List<Member>();

            members = hyDB.sp_Followers_GetMyFollowers(p_user_id).ToList();

            return members;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Member> GetMembersIFollow(int p_user_id)
        {
            List<Member> members = new List<Member>();

            members = hyDB.sp_Followers_GetMembersIFollow(p_user_id).ToList();
            

            return members;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public bool CheckIfAlreadyFollow(int User_ID, int Follower_ID)
        {
            bool ifAlreadyFollow = false;

            Follower fol = new Follower();
            fol = hyDB.sp_Followers_CheckIfAlreadyFollow(User_ID, Follower_ID).FirstOrDefault();

            if (fol != null && fol.UsFol_ID != 0)
                ifAlreadyFollow = true;

            return ifAlreadyFollow;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public void Delete_MemberIFollow(int User_ID, int Member_ID)
        {
            hyDB.sp_Followers_Delete_MemberIFollow(User_ID, Member_ID);
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void Delete_MyFollower(int User_ID, int Member_ID)
        {
            hyDB.sp_Followers_Delete_MyFollower(User_ID, Member_ID);
        }
        //----------------------------------------------------------------------------------------------------------



    }

}
