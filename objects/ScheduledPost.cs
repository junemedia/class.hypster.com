using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class ScheduledPost
    {
        public ScheduledPost()
        {
            id = 0;
            scheduled_date = new DateTime(1900, 1, 1);
            post_id = 0;
            activated = 0;
        }
    }

    public enum activated : int
    {
        NoActive = 0,
        Active = 1
    }
}
