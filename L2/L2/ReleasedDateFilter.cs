using System;

namespace L2
{
    public class ReleasedDateFilter :IFilter
    {
        public ReleasedDateFilter(DateTime date)
        {
            this.releasedDate = date;
        }
        private DateTime releasedDate;

        public bool Filter(Item item)
        {
            if (item.ReleaseDate >= this.releasedDate)
                return true;
            else
                return false;
        }
    }
}