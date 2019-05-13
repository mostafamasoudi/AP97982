namespace L2
{
    public class PriceFilter : IFilter
    {
        public PriceFilter(double priceboundary)
        {
            this.priceBoundary = priceboundary;
        }

        private double priceBoundary;

        public bool Filter(Item item)
        {
            if (item.Price <= priceBoundary)
                return true;
            else
                return false;
        }
    }
}