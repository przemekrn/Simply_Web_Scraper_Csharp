using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simply_Web_Scraper
{
    internal class Scraper
    {
        private const string Url = "https://www.formula1.com/en/results.html/2023/drivers.html";
        public IEnumerable<RacerInfo> ScrapeRiders()
        {
            var web = new HtmlWeb();
            var document = web.Load(Url);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1);
            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");
                var place = tds[1].InnerText;
                var fullName = tds[2].InnerText.Replace("\n", "").Trim();

                // Znajdź indeks pierwszej wielkiej litery w tekście
                int indexOfUpperCase = fullName.IndexOfAny(fullName.Where(char.IsUpper).ToArray());

                if (indexOfUpperCase >= 0)
                {
                    // Jeśli jest znaleziona wielka litera, podziel tekst na imię i nazwisko
                    var firstName = fullName.Substring(0, indexOfUpperCase);
                    var lastName = fullName.Substring(indexOfUpperCase);

                    yield return new RacerInfo(place, firstName, lastName);
                }
                else
                {
                    // Jeśli nie znaleziono wielkiej litery, użyj pełnego tekstu jako imienia
                    yield return new RacerInfo(place, fullName);
                }
            }
        }
    }
}
