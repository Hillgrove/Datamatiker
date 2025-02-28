using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrossTalk
{
    public class Reciter
    {
        private static Random _rng = new Random();

        /// <summary>
        /// Recites a set of lists of words.
        /// </summary>
        public static void ReciteAllTheWords()
        {
            List<string> danish = new List<string> { "En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte" };
            List<string> english = new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight" };
            List<string> german = new List<string> { "Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht" };

            Task reciteDanish = new Task(() => Recite(danish));
            Task reciteEnglish = new Task(() => Recite(english));
            Task reciteGerman = new Task(() => Recite(german));

            reciteDanish.Start();
            reciteEnglish.Start();
            reciteGerman.Start();

            Task.WaitAll(reciteDanish, reciteEnglish, reciteGerman);
        }

        /// <summary>
        /// Recites (i.e. prints on screen with a bit of delay
        /// between each line) the provided list of strings.
        /// </summary>
        public static void Recite(List<string> words)
        {
            foreach (string s in words)
            {
                Console.WriteLine(s);
                Thread.Sleep(_rng.Next(1000) + 50);
            }
        }
    }
}