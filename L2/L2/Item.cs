using System;

namespace L2
{
    public  class Item 
    {
        public Item(string title,double price,DateTime releasedate,string brand,string seller)
        {
            this.Id = 0;
            this.Title = title;
            this.Price = price;
            this.ReleaseDate = releasedate;
            this.Brand = brand;
            this.Seller = seller;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price;
        public DateTime ReleaseDate { get; set; }
        public string Brand { get; set; }
        public string Seller { get; set; }

        public double UpdatePrice(double newPrice)
        {
            if ((newPrice /this.Price)>1.2)
            {
                this.Price = this.Price * 1.2;
                return this.Price * 1.2;
            }
            this.Price = newPrice;
            return newPrice;    
        }
        

    }
}
