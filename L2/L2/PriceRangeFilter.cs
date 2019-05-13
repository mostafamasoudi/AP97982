namespace L2
{
    public class PriceRangeFilter :IFilter
    {
        public PriceRangeFilter(double start,double stop)
        {
            this.startRange = start;
            this.stopRange = stop;
        }
        private double startRange;
        private double stopRange;
        
        public bool Filter(Item item)
        {
            if (item.Price >= this.startRange && item.Price <= this.stopRange)
                return true;
            else
                return false;
        }

    }
}