using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class Mobile_Device_Recognition
    {

        public Mobile_Device_Recognition()
        {

        }



        public static bool CheckIfTablet(string userAgent)
        {
            
            if (userAgent.IndexOf("iPad") > -1 || userAgent.Contains("tablet"))
            {
                return true;
            }


            return false;
        }



    }
}
