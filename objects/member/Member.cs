using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class Member
    {
        public Member()
        {
            _id = 0;
            _username = string.Empty;
            _password = string.Empty;
            _email = string.Empty;
            _name = string.Empty;
            _country = string.Empty;
            _city = string.Empty;
            _sex = 0;
            _zipcode = "";
            _birth = new DateTime(1900,1,1);
            _introduce = "";
            _regdate = new DateTime(1900,1,1);
            _trackcount = 0;
            _israndomplay = 0;
            _active_playlist = 0;
            _profile_pic_id = 0;
            _is_new_artist = 0;
            _autoplay = 0;
            _email_confirmed = 0;
            _email_optout = 0;
            _widget_views = 0;
            _RegistrationIp = "";
            _LastActivityDate = new DateTime(1900,1,1);
            _LastActivityIp = "";
            _CoregProcessed = false;
            _OptOutDate = new DateTime(1900,1,1);
            _IsSuspended = false;
            _StatusId = 0;
            _AutoshareEnabled = false;
            _ArtistLevel = 0;
            _IsOverEighteen = false;
            _user_interest = 0;
        }

    }



    public enum NewsletterOptions
    {
        None = 0,
        Players = 1,
        Playlists = 2,
        Both = 3
    }

}
