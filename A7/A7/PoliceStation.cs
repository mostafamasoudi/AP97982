using System;
using System.Collections.Generic;

namespace A7
{
    public static class PoliceStation
    {
        
        public static List<ICitizen> BlackList
        {
            get;
            set;
        }
        public static bool BackgroundCheck(ICitizen citizen)
        {
            foreach(var blacklist in BlackList)
            {
                if (citizen == blacklist)
                    return true;
            }
            return false;
        }
    }
}