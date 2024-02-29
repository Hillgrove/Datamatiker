
// By: Jesper Højlund

using ByGuide.Models;

namespace ByGuide.MockData
{
    public class MockPosts
    {
        #region Static Fields
        private static List<Post> _posts = new List<Post>()
        {
            new Post(1,
                    "Odd Fellow Julekoncert",
                    "En juletradition i Roskilde Domkirke er Odd Fellows velgørenhedskoncert. I år kan du opleve " +
                    "Anne Dorte Michelsen synge julen ind. Midt i det mørke vi går ind i, når vinteren for alvor " +
                    "rammer, er sangene som et lys vi kan tænde for hinanden.",
                    "Koncert",
                    "Roskilde Domkirke",
                    "https://saintcyrils.church/wp-content/uploads/2020/12/Christmas-Concert-3.jpg"),
            new Post(2,
                    "Jul på Ryegaard",
                    "Til Jul på Ryegaard kan du tage familien med ud og køre hestevogn for at fælde årets juletræ. " +
                    "Tilbage i Ryegaard Park kan I besøge Brandsprøjtehuset, hvor der serveres æbleskiver, gløgg, " +
                    "kakao. Besøg også det lille hyggelige julemarked.",
                    "Marked/Byfest",
                    "Ryegaard Park"),
            new Post(3,
                    "Gimle Comedy Club - Open Mic",
                    "Open Mic på Gimle er tilbage og stand-up-komikerne er ved at koge over af idéer og jokes, der " +
                    "skal afprøves. Gimles Comedy Club holder til i Gimles Kælder, hvor der er god plads til gæster " +
                    "med hang til et godt grin.",
                    "Show/stand up",
                    "Gimle")
        };
        #endregion

        #region Methods
        public static List<Post> GetMockPosts()
        {
            return _posts;
        }
        #endregion
    }
}
