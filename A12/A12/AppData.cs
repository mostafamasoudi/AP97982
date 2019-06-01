using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public class AppData
    {
        public string Name;
        public string Category;
        public double Rating;
        public long Reviews;
        public double Size;
        public long Installs;
        public bool IsFree;
        public double Price;
        public string ContentRating;
        public List<string> Genres;
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;

        public AppData(string[] appData)
        {
            this.Name = appData[0];

            this.Category = appData[1];

            if (!double.TryParse(appData[2], out this.Rating))
                this.Rating = 0;

            if (!long.TryParse(appData[3], out this.Reviews))
                this.Reviews = 0;

            if (!double.TryParse(appData[4].TrimEnd('M', 'k'), out this.Size))
                this.Size = 0;

            if (!long.TryParse(appData[5].Trim('"'),
                NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign,
                CultureInfo.InvariantCulture,
                out this.Installs))
                this.Installs = 0;

            this.IsFree = appData[6].ToLower().Contains("free") ? true : false;

            this.Price = double.Parse(appData[7].Trim('$'));

            this.ContentRating = appData[8];

            this.Genres = appData[9].Split(';', '&').ToList();

            if ((int.Parse(appData[10].Split('-')[0]) / 10) == 0)
                appData[10] = $"0{appData[10]}";
            this.LastUpdate = DateTime.ParseExact(appData[10], "dd-MMM-yy", CultureInfo.InvariantCulture);

            this.CurrentVersion = appData[11];

            this.AndroidVersion = appData[12];
            
        }
    }
}
