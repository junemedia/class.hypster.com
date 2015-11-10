using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace hypster_tv_DAL
{
    public class listenHistoryManagement
    {

        //----------------------------------------------------------------------------------------------------------
        private Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public listenHistoryManagement()
        {
        }



        public void AddListenHistory(ListenHistory hist)
        {
            hyDB.ListenHistories.AddObject(hist);
            hyDB.SaveChanges();
        }


        public List<ListenHistory> GetLatestListenHistoryUser(int user_id)
        {
            List<ListenHistory> hist_list = new List<ListenHistory>();

            hist_list = hyDB.sp_ListenHistory_GetLatestListenHistoryUser(user_id).ToList();

            return hist_list;
        }



        public List<ListenHistory> GetListenHistoryUser(int user_id)
        {
            List<ListenHistory> hist_list = new List<ListenHistory>();

            hist_list = hyDB.sp_ListenHistory_GetListenHistoryUser(user_id).ToList();

            return hist_list;
        }



    }
}
