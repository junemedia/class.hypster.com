using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace hypster_tv_DAL
{
    public class chartsManager
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();


        private string _sql_connection_string = "";
        private SqlCommand _command = new SqlCommand();
        private SqlConnection _con = new SqlConnection();
        //----------------------------------------------------------------------------------------------------------




        public chartsManager()
        {
            _sql_connection_string = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }




        public List<Chart> GetAllCharts()
        {
            List<Chart> charts_list = new List<Chart>();

            charts_list = hyDB.sp_Charts_GetAllCharts().ToList();

            return charts_list;
        }


        public List<Chart> GetTopCharts()
        {
            List<Chart> charts_list = new List<Chart>();

            
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["GetTopCharts"] != null)
            {
                charts_list = (List<Chart>)i_chache["GetTopCharts"];
            }
            else
            {
                charts_list = hyDB.sp_Charts_GetTopCharts().ToList();
                i_chache.Add("GetTopCharts", charts_list, DateTime.Now.AddSeconds(11000));
            }


            return charts_list;
        }




        public void AddNewChart(Chart p_chart)
        {
            hyDB.Charts.AddObject(p_chart);
            hyDB.SaveChanges();
        }


        public void SaveChart(Chart chart_update)
        {
            hyDB.sp_Charts_SaveChart(chart_update.Chart_ID, chart_update.Chart_Category_ID, chart_update.Chart_Name, chart_update.Chart_Desc, chart_update.Chart_Date, chart_update.Chart_User_ID, chart_update.Chart_Playlist_ID);
        }


        public void DeleteChart(int chart_id)
        {
            hyDB.sp_Charts_DeleteChart(chart_id);
        }








        public Chart GetChartByGuid(string chart_guid)
        {
            Chart chart = new Chart();


            chart = hyDB.sp_Charts_GetChartByGuid(chart_guid).FirstOrDefault();
            if (chart == null)
                chart = new Chart();


            return chart;
        }





        public List<hypster_tv_DAL.MostPopularHypsterSongs_Result> GetMostPopularHypsterSongs(int p_limit, int p_cut_off_id = 0)
        {
            List<hypster_tv_DAL.MostPopularHypsterSongs_Result> list = new List<MostPopularHypsterSongs_Result>();

            
            _con = new SqlConnection(_sql_connection_string);
            SqlDataReader reader = null;
            
            string _err_message;
            try
            {
                _con.Open();
                _command = new SqlCommand("sp_Charts_GetMostPopularHypsterSongs", _con);
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandTimeout = 80;
                _command.Parameters.Add("@p_top_num", SqlDbType.Int).Value = p_limit;
                _command.Parameters.Add("@p_cut_off_id", SqlDbType.Int).Value = p_cut_off_id;
                reader = _command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        hypster_tv_DAL.MostPopularHypsterSongs_Result item = new hypster_tv_DAL.MostPopularHypsterSongs_Result();

                        if (reader["id"] != DBNull.Value)
                            item.id = (int)reader["id"];

                        if (reader["SongsNum"] != DBNull.Value)
                            item.SongsNum = (int)reader["SongsNum"];

                        if (reader["Title"] != DBNull.Value)
                            item.Title = (string)reader["Title"];

                        if (reader["YoutubeId"] != DBNull.Value)
                            item.YoutubeId = (string)reader["YoutubeId"];

                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _err_message = ex.ToString();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                _con.Close();
            }



            return list;
        }



    }
}
