using System;

namespace projGameLauncherCsharp
{
    public class Game
    {

        public static int numberOfGames = 0;

        public string Name { get; set; }
        public string Location { get; set; }
        public string Picture { get; set; }

        public Game()
        {
            numberOfGames++;
        }

        internal static void ResetNumberOfGames()
        {
            numberOfGames = 0;
        }
    }//class
}//namespace