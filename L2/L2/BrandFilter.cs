namespace L2
{
    public class BrandFilter :IFilter
    {
        public BrandFilter(string brand)
        {
            this.Brand = brand;
        }
        private string Brand;

        public bool Filter(Item item)
        {
            if (item.Brand == this.Brand)
                return true;
            else
                return false;
        }
    }
}