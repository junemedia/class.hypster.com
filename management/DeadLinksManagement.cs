using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class DeadLinksManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public DeadLinksManagement()
        {
        }


        public int SubmitDeadLink(hypster_tv_DAL.Dead_Link p_dl)
        {
            int new_id = 0;

            System.Data.Objects.ObjectParameter param = new System.Data.Objects.ObjectParameter("p_new_id", typeof(int));

            hyDB.sp_DeadLink_SubmitDeadLink(p_dl.Dead_Link_ID, p_dl.DL_Member_ID, p_dl.DL_Song_Guid, p_dl.DL_Song_ID, p_dl.DL_ErrorNum, param);

            new_id = (int)param.Value;

            return new_id;
        }





    }
}
