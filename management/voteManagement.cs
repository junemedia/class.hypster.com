using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class voteManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        public voteManagement()
        {
        }


        public int VoteFor(int US_ID, int VOTE_FOR)
        {
            int retNum = 0;
            retNum = (int)hyDB.sp_MemberVote_VoteFor(US_ID, VOTE_FOR).FirstOrDefault();
            return retNum;
        }



        public int GetVotesNum(int VOTE_FOR)
        {
            int retNum = 0;
            
            retNum = (int)hyDB.sp_MemberVote_GetVotesNum(VOTE_FOR).FirstOrDefault();
            
            return retNum;
        }



        public void AddNew_VoteForSong(hypster_tv_DAL.VoteForSong vfs)
        {
            hyDB.ExecuteStoreCommand(" DELETE FROM VoteForSong");
            hyDB.ExecuteStoreCommand(" DELETE FROM VoteOnLogo ");

            hyDB.VoteForSongs.AddObject(vfs);
            hyDB.SaveChanges();
        }



        public VoteForSong Get_Active_VoteForSong()
        {
            VoteForSong currVfs = new VoteForSong();


            currVfs = hyDB.sp_VoteForSong_GetActiveVoteForSong().FirstOrDefault();
            if (currVfs == null)
                currVfs = new VoteForSong();


            return currVfs;
        }



        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------



        public List<CoverContest> GetAllCoverContestSongs()
        {
            List<CoverContest> covers_list = new List<CoverContest>();

            covers_list = hyDB.sp_CoverContest_GetAllCoverContestSongs().ToList();

            return covers_list;
        }



        public int VoteForContest(int VOTE_FOR, string IP_ADDRESS, DateTime dt)
        {
            int retNum = 0;


            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("p_new_id", typeof(int));

            hyDB.sp_CoverContestVote_VoteForContest(VOTE_FOR, IP_ADDRESS, dt, param);

            if(param.Value != null)
                retNum = (int)param.Value;
            

            return retNum;
        }


    }
}
