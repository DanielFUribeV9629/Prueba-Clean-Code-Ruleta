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
                idRoulette = logicGameRoulette.CreateRoulette();
            }
            Console.ReadKey();
        }
    }
}
