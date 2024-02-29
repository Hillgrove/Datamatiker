
// By: Jesper Højlund

using ByGuide.Models;

namespace ByGuide.MockData
{
    public class MockExperiences
    {
        #region Instance Fields - Test Data
        public static List<Experience> _experiences = new List<Experience>()
        {
            new Experience(
                1,
                "Udenfor lands lov og ret",
                "Kør i en stor bue uden om Venslev. De er farlige. De plyndrer enhver der kommer i nærheden af dem, stjæler fra hinanden og slår ihjel for et godt ord. De er udenfor pædagogisk rækkevide - ville man ha sagt i dag, Men så bliver Politiassessor Peter Munthe Brun sat på sagen, han formår at få de anklagede til at tale hvor alle andre har givet op. Et Psykologisk drama om at forstå mennesker i stedet for at tage afstand til dem",
                "Kultur og Historie",
                120,
                "Kyndeløse Strandvej 22, Kirke Hyllinge",
                "https://www.parkteatret.dk/#select/114607",
                true,
                "https://www.teaterbilletter.dk/wp-content/uploads/2023/05/Udenfor-lands-lov-og-ret.jpg",
                new Dictionary<string, string>
                {
                    { "Mandag", "Lukket" },
                    { "Tirsdag", "9 - 17" },
                    { "Onsdag", "9 - 17" },
                    { "Torsdag", "9 - 17" },
                    { "Fredag", "9 - 17" },
                    { "Lørdag", "10 - 20" },
                    { "Søndag", "Lukket" },
                }),
            new Experience(
                2,
                "Tim Christensen",
                "Dizzy Mizz Lizzy-frontfiguren tager for første gang i over 10 år på band-turné i eget navn og genbesøger sit mest populære album. Tim Christensens album.",
                "Kultur og Historie",
                350,
                "Helligkorsvej 2, Roskilde",
                "https://www.kultunaut.dk/perl/billet/type-fjordlandet?ArrNr=16490795",
                true,
                "",
                new Dictionary<string, string>
                {
                    { "Mandag", "Lukket" },
                    { "Tirsdag", "9 - 17" },
                    { "Onsdag", "9 - 17" },
                    { "Torsdag", "9 - 17" },
                    { "Fredag", "9 - 17" },
                    { "Lørdag", "10 - 20" },
                    { "Søndag", "Lukket" },

                }),
            new Experience(
                3,
                "Roskilde Håndbold Herrer - FIF 2",
                "Kom og se og støt Roskildes bedste hold! Det er utrolig vigtigt, at Roskilde på hjemmebane har så mange, der kommer til kampene og støtter op om holdet.",
                "Begivenheder og Aktiviteter",
                50,
                "Møllehusvej 15, Roskilde",
                "https://www.billetsalg.dk/Event/Roskilde%20H%C3%A5ndbold%20Herrer%20-%20FIF%202/4994?",
                true,
                "",
                new Dictionary<string, string>
                {
                    { "Mandag", "Lukket" },
                    { "Tirsdag", "9 - 17" },
                    { "Onsdag", "9 - 17" },
                    { "Torsdag", "9 - 17" },
                    { "Fredag", "9 - 17" },
                    { "Lørdag", "10 - 20" },
                    { "Søndag", "Lukket" },
                })
        };
        #endregion

        #region Methods
        public static List<Experience> GetMockExperiences()
        {
            return _experiences;
        }
        #endregion
    }
}
