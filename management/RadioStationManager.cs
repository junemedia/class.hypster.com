using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace hypster_tv_DAL
{
    public class RadioStationManager
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        public RadioStationManager()
        {
        }



        public List<RadioStation> GetUserRadioStations(int user_id)
        {
            List<RadioStation> radioStations = new List<RadioStation>();

            radioStations = hyDB.sp_RadioStation_GetUserRadioStations(user_id).ToList();

            return radioStations;
        }



        public void DeleteUserRadioStation(int user_id, int station_id)
        {
            hyDB.sp_RadioStation_DeleteUserRadioStation(user_id, station_id);
        }


        

    }
}
