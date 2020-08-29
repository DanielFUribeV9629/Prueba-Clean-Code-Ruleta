using System;
namespace Roulette
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numberOfGames = 2; int numberOfUsers = 2; int idRoulette;
            LogicGameRoulette logicGameRoulette = new LogicGameRoulette();
            for (int id = 0; id < numberOfUsers; id++)
            {
                logicGameRoulette.CreateUser(id);
            }
            for (int id = 0; id < numberOfGames; id++)
            {
                Console.WriteLine("\n -----Welcome to the Roulette Game-----");
                Console.WriteLine("The game number " + (id + 1) + " is starting...");
                idRoulette = logicGameRoulette.CreateRoulette();
                logicGameRoulette.playersWhoWantToPlay(idRoulette);
                logicGameRoulette.rouletteClosing(idRoulette);
            }
            logicGameRoulette.viewCreatedRoulettes();
            Console.ReadKey();
        }
    }
}
