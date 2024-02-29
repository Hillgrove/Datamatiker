using ByGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByGuide.MockData
{
    public class MockEvents
    {
        #region Static Fields
        private static List<Event> _events = new List<Event>()
        {           
            new Event(
                "BANKO Byens hyggeligste banko for medlemmer vi hygger os vi har plads til 80 spillere der er kaffe brød osv ti rimelige priser.",
                0,
                new List < DateTime > { new DateTime(2023, 12, 19) },
                new Uri("https://www.roskildelive.dk/perl/arrmore/type-roskilde5?ArrNr=16887725"),
                true
            ),
            new Event(
                "Plexus Roskilde Åbningsdag - Juleafslutning\r\nPlexus Roskilde er et mødested for ensomme unge i alderen 18-35 år. På en åbningsdag handler vi ind, laver mad og spiser sammen. Derudover spiller vi en masse spil og har en masse hyggeligt samvær i trygge rammer.",
                0,
                new List < DateTime > { new DateTime(2023, 12, 21) },
                new Uri("https://www.roskildelive.dk/perl/arrmore/type-roskilde5?ArrNr=17078187"),
                true
            ),
            new Event(
                "Køb dit juletræ og støt FDF Roskilde, Køb dit juletræ hos FDF Roskilde. Vi har et bredt udvalg af nordmannsgran og rødgran. Når du køber dit juletræ hos os, støtter du samtidig FDF Roskilde.",
                0,
                new List < DateTime > { new DateTime(2023, 12, 25) },
                new Uri("https://www.fdfroskilde.dk/2023/11/16/juletrae/"),
                false
            ),
            new Event(
                "Koncert med Martin Dale (irsk folkemusik & rock/pop classics)\r\n\"Den britiske sanger, guitarist og entertainer Martin Dale er en meget dygtig og erfaren musiker, men det er hans evne til at underholde, der imponerer mest, når man oplever hans meget eftertragtede troubadour-show.",
                50,
                new List < DateTime > { new DateTime(2023, 12, 22) },
                new Uri("https://billetto.dk/e/koncert-med-martin-dale-irsk-folkemusik-rock-pop-classics-billetter-879360?utm_campaign=websites&utm_content=DK+4192315&utm_medium=publishers&utm_source=billetto+advertising&vs=510105ff-67ca-48e7-be2e-6885ebef6556"),
                true
            ),
            new Event(
                "Julekonkurrence: Find nissen?",
                0,
                new List < DateTime > { new DateTime(2023, 12, 30) },
                new Uri("https://www.roskildelive.dk/perl/arrmore/type-roskilde5?ArrNr=17139267"),
                false
            ),
        };
        #endregion

        #region Methods
        public static List<Event> GetMockEvents()
        {
            return _events;
        }
        #endregion
    }
}