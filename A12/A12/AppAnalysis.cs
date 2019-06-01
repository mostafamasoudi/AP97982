using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps;

        private AppAnalysis()
        {
            this.Apps = new List<AppData>();
        }

        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
         
            //AppAnalysis appAnalysis = new AppAnalysis();
            //var appsData=File.ReadAllLines(appDataPath);
            //appsData.Skip(1)
            //        .ToList()
            //        .ForEach(d => appAnalysis.Apps.Add(new AppData(d.Split(','))));
            //return appAnalysis;
        }

        private void AppendApp(string[] fields)
        {
            this.Apps.Add(new AppData(fields));
        }

        public long AllAppsCount()
            => Apps.Count;
        

        public long AppsAboveXRatingCount(double x)
        {
            long count = 0;
            Apps.ForEach(
                d => {
                    if (d.Rating >= x)
                        count++;
                });
            return count;
        }

        public long RecentlyUpdatedCount(DateTime boundary)
            => Apps.Where(d => d.LastUpdate >= boundary)
                   .Count();

        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            return Apps.Where(d => d.LastUpdate >= boundary)
                       .GroupBy(d => d.Category)
                       .OrderByDescending(g => g.Count())
                       .Select(d => d.Key)
                       .First();
        }
            
        public List<string> MostRatedCategories(double ratingBoundary,int n)
        {
            var a= Apps.Where(d => d.Rating > ratingBoundary)
                .GroupBy(d => d.Category)
                .OrderByDescending(g => g.Count())
                .Select(d => d.Key)
                .Take(n)
                .ToList();
            a.ForEach(d => Console.WriteLine(d));
            return a;

        }

        public double TopQuarterBoundary()
        {
            var List = Apps.Where(d => d.Category.ToUpper().Contains("PHOTOGRAPHY"))
                           .OrderByDescending(d => d.Rating);

            return List.Select(d => d.Rating)
                       .ElementAt(List.Count() / 4);           
        }

        public Tuple<string, string> ExtremeMeanUpdateElapse(DateTime today)
        {
            var avgGroup = Apps.Select(d => new
            {
                category = d.Category,
                lastupdate = today.Ticks - d.LastUpdate.Ticks
            })
            .GroupBy(d => d.category)
            .Select(g => new
            {
                avg = g.Average(d => d.lastupdate),
                name = g.Key
            });
            
            var maxValue = avgGroup.Aggregate((d1, d2) => d1.avg > d2.avg ? d1 : d2);
            var minValue = avgGroup.Aggregate((d1, d2) => d1.avg < d2.avg ? d1 : d2);
            return Tuple.Create<string, string>(minValue.name, maxValue.name);
        }

        public List<string> XMostProfitables(int x)
        {
            return Apps.Where(d => !d.IsFree)
                        .Select(d => new
            {
                value = d.Installs * d.Price,
                name = d.Name
            })
            .OrderByDescending(d => d.value)
            .Take(x)
            .Select(d => d.name)
            .ToList();
        }

        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            return Apps.Select(d => new
            {
                name = d.Name,
                value = criteria(d)
            })
            .OrderBy(d => d.value)
            .Take(x)
            .Select(d => d.name)
            .ToList();
        }

    }
}
