using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simply_Web_Scraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var scraper = new Scraper();
                var riders = scraper.ScrapeRiders();
                var formattedRiders = riders.Select(rider => $"Place: {rider.Place}. {rider.Name}");

                Console.WriteLine(string.Join(Environment.NewLine, formattedRiders));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
