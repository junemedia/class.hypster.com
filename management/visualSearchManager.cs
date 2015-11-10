using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public class visualSearchManager
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public visualSearchManager()
        {
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void addVisualSearch(VisualSearch visSearch)
        {
            hyDB.VisualSearches.AddObject(visSearch);
            hyDB.SaveChanges();
        }
        //----------------------------------------------------------------------------------------------------------



        // +++++
        //----------------------------------------------------------------------------------------------------------
        public List<VisualSearch> getVisualSearchArtists_cached()
        {
            List<VisualSearch> visualSearch_list = new List<VisualSearch>();
            

            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["VisualSearch_List"] != null)
            {
                visualSearch_list = (List<VisualSearch>)i_chache["VisualSearch_List"];
            }
            else
            {
                visualSearch_list = hyDB.sp_VisualSearch_getVisualSearchArtists().ToList();
                i_chache.Add("VisualSearch_List", visualSearch_list, DateTime.Now.AddSeconds(120));
            }


            return visualSearch_list;
        }
        //----------------------------------------------------------------------------------------------------------




        // +++++
        //----------------------------------------------------------------------------------------------------------
        public List<VisualSearch> getVisualSearchArtists()
        {
            List<VisualSearch> visualSearch_list = new List<VisualSearch>();

            visualSearch_list = hyDB.sp_VisualSearch_getVisualSearchArtists().ToList();
            
            return visualSearch_list;
        }
        //----------------------------------------------------------------------------------------------------------



        public VisualSearch getVisualSearchArtistByName(string art_name)
        {
            VisualSearch vsArtist = new VisualSearch();

            vsArtist = hyDB.sp_VisualSearch_getVisualSearchArtistByName(art_name).FirstOrDefault();
            if (vsArtist == null)
            {
                vsArtist = new VisualSearch();
            }

            return vsArtist;
        }




        public List<VisualSearch> getVisualSearchArtistsByGenreID(int p_genre_id)
        {
            List<VisualSearch> model = new List<VisualSearch>();

            model = hyDB.sp_VisualSearch_getVisualSearchArtistsByGenreID(p_genre_id).ToList();

            return model;
        }




        public List<VisualSearch> getVisualSearchArtistsByGenres(int genre1, int genre2, int genre3, int genre4, int genre5, int genre6)
        {
            List<VisualSearch> model = new List<VisualSearch>();

            model = hyDB.sp_VisualSearch_getVisualSearchArtistsByGenres(genre1, genre2, genre3, genre4, genre5, genre6).ToList();

            return model;
        }





        public VisualSearch getVisualSearchArtistByID(int artist_id)
        {
            VisualSearch model = new VisualSearch();

            model = hyDB.sp_VisualSearch_getVisualSearchArtistByID(artist_id).FirstOrDefault();
            if (model == null)
                model = new VisualSearch();


            return model;
        }



        public void DeleteArtist(int artist_id)
        {
            hyDB.sp_VisualSearch_DeleteArtist(artist_id);
        }


    }
}
