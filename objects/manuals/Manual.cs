using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hypster_tv_DAL
{
    public partial class Manual
    {


        public Manual()
        {
            _Manual_Active = 0;
            _Manual_Date = new DateTime(1900, 1, 1);
            _Manual_Guid = "";
            _Manual_Header = "";
            _Manual_ID = 0;
        }


    }
}
