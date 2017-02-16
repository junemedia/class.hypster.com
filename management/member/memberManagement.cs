using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace hypster_tv_DAL
{
    public class memberManagement
    {
        //----------------------------------------------------------------------------------------------------------
        public Hypster_Entities hyDB = new Hypster_Entities();
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public memberManagement()
        {
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public bool ValidateUser(string p_username, string p_password)
        {
            bool checkRes = false;

            
            var member = hyDB.sp_Members_ValidateMember(p_username, p_password).FirstOrDefault();
            if (member != null && member.id != 0)
                checkRes = true;

            return checkRes;
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public Member getMemberByID(int p_member_id)
        {
            Member member = new Member();

            member = hyDB.sp_Members_getMemberByID(p_member_id).FirstOrDefault();
            if (member == null)
                member = new Member();


            return member;
        }
        //----------------------------------------------------------------------------------------------------------



       

        
        //----------------------------------------------------------------------------------------------------------
        // this method needs caching since called almost in every section
        public Member getMemberByUserName(string user_name)
        {
            Member member = new Member();

            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            if (i_chache["Member_" + user_name] != null)
            {
                member = (Member)i_chache["Member_" + user_name];
            }
            else
            {
                member = hyDB.sp_Members_getMemberByUserName(user_name).FirstOrDefault();
                if (member == null)
                    member = new Member();
                else
                    i_chache.Add("Member_" + user_name, member, DateTime.Now.AddSeconds(1800)); //30 mins
            }


            return member;
        }
        

        //used for user editing
        public void CleanMemberFromCache(string p_user_name)
        {
            System.Runtime.Caching.ObjectCache i_chache = System.Runtime.Caching.MemoryCache.Default;
            i_chache.Remove("Member_" + p_user_name);
        }
        //----------------------------------------------------------------------------------------------------------







        //----------------------------------------------------------------------------------------------------------
        public Member getMemberByEmail(string email)
        {
            Member member = new Member();

            member = hyDB.sp_Members_getMemberByEmail(email).FirstOrDefault();
            if (member == null)
                member = new Member();


            return member;
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns Random members list (returns only AutoshareEnabled users)
        /// </summary>
        /// <param name="p_num_of_users"></param>
        /// <returns></returns>
        public List<Member> GetMembersRandom(int p_num_of_users = 25)
        {
            List<Member> members_list = new List<Member>();

            members_list = hyDB.sp_Members_GetMembersRandom(p_num_of_users).OrderBy(x => Guid.NewGuid()).ToList();

            return members_list;
        }
        //----------------------------------------------------------------------------------------------------------





        public List<Member> GetNewMembersRegistrations(DateTime p_date)
        {
            List<Member> members_list = new List<Member>();

            members_list = hyDB.sp_Members_GetNewMembersRegistrations(p_date.Year, p_date.Month, p_date.Day).ToList();

            return members_list;
        }








        //----------------------------------------------------------------------------------------------------------
        #region UPDATE_MEMBER


        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberPassword(string user_name, int member_id, string member_password)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_updateMemberPassword(member_id, member_password);
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberUsername(string user_name, int member_id)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_updateMemberUsername(member_id, user_name);
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberActivityData(string user_name, int member_id, DateTime LastActivityDate, string LastActivityIp)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberActivityData(member_id, LastActivityDate, LastActivityIp);
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberTrackData(string user_name, int member_id)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberTrackData(member_id);
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        public void SetUserDefaultPlaylist(string user_name, int p_user_id, int p_playlist_id)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_SetUserDefaultPlaylist(p_user_id, p_playlist_id);
        }
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberProfileDetails(string user_name, int id, string name, bool AutoshareEnabled, DateTime birth, string city, string country, string zipcode, byte sex)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberProfileDetails(id, name, AutoshareEnabled, birth, city, country, zipcode, sex);
        }

        public void UpdateMemberProfileDetailsNameEmailAdminLevel(string user_name, int id, string name, string email, int adminLevel)
        {   
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberProfileDetails2(id, name, email, adminLevel);
        }

        public void UpdateMemberProfileDetails(string user_name, int id, string name, bool AutoshareEnabled, DateTime birth, string city, string country, string zipcode, byte sex, int user_interest, int email_optout)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberProfileDetails3(id, name, AutoshareEnabled, birth, city, country, zipcode, sex, user_interest, email_optout);
        }

        public void UpdateMemberProfileDetails(string user_name, int id, string firstname, string lastname, string address, string state, string introduce)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberProfileDetails4(id, firstname, lastname, address, state, introduce);
        }


        public void UpdateMemberEmailConfirmed(string user_name, int id, int email_confirmed)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberEmailConfirmed(id, user_name, email_confirmed);
        }
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberProfilePicture(string user_name, int user_id, int picture_id)
        {
            CleanMemberFromCache(user_name);
            hyDB.sp_Members_UpdateMemberProfilePicture(user_id, picture_id);
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void UpdateMemberData(int user_id, string update_stream)
        {
            hyDB.sp_Members_UpdateMemberData(user_id, update_stream);
        }
        //----------------------------------------------------------------------------------------------------------

        #endregion
        //----------------------------------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------------------------------
        public List<Member> GetMembersWithSong(int song_id)
        {
            List<Member> members_with_song_list = new List<Member>();

            members_with_song_list = hyDB.sp_Members_GetMembersWithSong(song_id).ToList();
            
            return members_with_song_list;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public List<Member> GetMembersWithGenre(int genre_id)
        {
            List<Member> members_with_song_list = new List<Member>();

            members_with_song_list = hyDB.sp_Members_GetMembersWithGenre(genre_id, 1000).ToList();
            
            return members_with_song_list;
        }
        //----------------------------------------------------------------------------------------------------------
        











        //----------------------------------------------------------------------------------------------------------
        public void DeactivateUser(int user_id)
        {
            hyDB.sp_Members_DeactivateMember(user_id);
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public bool isActiveCheck(int user_id)
        {
            bool isActive_check = true;


            Members_DeactivateCheck_Result Deactivated = new Members_DeactivateCheck_Result();
            Deactivated = hyDB.sp_Members_DeactivateCheck(user_id).FirstOrDefault();

            if (Deactivated != null)
            {
                if (Deactivated.UserId == user_id && Deactivated.IsDeActivated == 1)
                    isActive_check = false;
            }

            return isActive_check;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public void DeleteDeactivatedUser(int user_id)
        {
            hyDB.sp_Members_DeleteDeactivatedUser(user_id);
        }
        //----------------------------------------------------------------------------------------------------------






        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------
        public void AddMemberPublicPage(MemberPublicPage p_publicPage)
        {
            hyDB.MemberPublicPages.AddObject(p_publicPage);
            hyDB.SaveChanges();
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public void EditMemberPublicPage(MemberPublicPage p_publicPage)
        {
            hyDB.sp_Members_EditMemberPublicPage(
                p_publicPage.PublicPage_ID,
                p_publicPage.showHeader,
                p_publicPage.showDescription,
                p_publicPage.autoplay,
                p_publicPage.showLikeButtton,
                p_publicPage.showInfoButton,
                p_publicPage.showPhotosButton,
                p_publicPage.header,
                p_publicPage.description,
                p_publicPage.HaFBackgroundColor,
                p_publicPage.BackgroundColor,
                p_publicPage.LeftSectionColor,
                p_publicPage.RightSectionColor,
                p_publicPage.ButtonsBackgroundColor,
                p_publicPage.SongBackgroundColor,
                p_publicPage.TextColor,
                p_publicPage.ButtonsColor,
                p_publicPage.Playlist_ID,
                p_publicPage.Playlist_Layout);
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public MemberPublicPage GetMemberPublicPageByID(int member_id)
        {
            MemberPublicPage publicPage = new MemberPublicPage();

            publicPage = hyDB.sp_Members_GetMemberPublicPageByID(member_id).FirstOrDefault();
            if (publicPage == null)
                publicPage = new MemberPublicPage();

            return publicPage;
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public MemberPublicPage GetMemberPublicPageByPlaylistID(int member_id, int playlist_id)
        {
            MemberPublicPage publicPage = new MemberPublicPage();

            publicPage = hyDB.sp_Members_GetMemberPublicPageByPlaylistID(member_id, playlist_id).FirstOrDefault();
            if (publicPage == null)
                publicPage = new MemberPublicPage();

            return publicPage;
        }
        //----------------------------------------------------------------------------------------------------------



        //----------------------------------------------------------------------------------------------------------
        public MemberPublicPage GetMemberPublicPageByPlaylistID(int playlist_id)
        {
            MemberPublicPage publicPage = new MemberPublicPage();

            publicPage = hyDB.sp_Members_GetMemberPublicPageByOnlyPlaylistID(playlist_id).FirstOrDefault();
            if (publicPage == null)
                publicPage = new MemberPublicPage();

            return publicPage;
        }
        //----------------------------------------------------------------------------------------------------------








        //----------------------------------------------------------------------------------------------------------
        public List<MemberPublicPage> GetMembersPublicPagesRandom(int p_num_of_users = 25)
        {
            List<MemberPublicPage> model = new List<MemberPublicPage>();

            model = hyDB.sp_Members_GetMembersPublicPagesRandom(p_num_of_users).OrderBy(x => Guid.NewGuid()).ToList();

            return model;
        }
        //----------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------------------------------------------------------
        public List<sp_Members_GetMembersPublicPagesRandomEx_Result> GetMembersPublicPagesRandomEx(int p_num_of_users = 25)
        {
            List<sp_Members_GetMembersPublicPagesRandomEx_Result> model = new List<sp_Members_GetMembersPublicPagesRandomEx_Result>();

            model = hyDB.sp_Members_GetMembersPublicPagesRandomEx(p_num_of_users).OrderBy(x => Guid.NewGuid()).ToList();

            return model;
        }
        //----------------------------------------------------------------------------------------------------------




        public void ConfirmMember(Member member_conf)
        {
            CleanMemberFromCache(member_conf.username);

            hyDB.sp_Members_ConfirmMember(member_conf.id);

            CleanMemberFromCache(member_conf.username);
        }


    }
}
