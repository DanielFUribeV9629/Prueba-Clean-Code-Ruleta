using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class LogicGameRoulette
    {
        List<Roulette> rouletteList = new List<Roulette>();
        List<User> userList = new List<User>();
        public void CreateUser(int id)
        {
            User user = new User();
            user.setUserId(id);
            user.setUserName("");
            user.setUserCredit(10000f);
            userList.Add(user);
        }
        public int CreateRoulette()
        {
            Roulette roulette = new Roulette();
            roulette.setIdRoulette(rouletteList.Count());
            rouletteList.Add(roulette);
            return roulette.getIdRoulette();
        }
        public void playersWhoWantToPlay(int idRoulette)
        {
            Roulette roulette = rouletteList[idRoulette];
            for (int i = 0; i < userList.Count(); i++)
            {
                Console.WriteLine("Player " + userList[i].getUserId() + ": Are you going to play?");
                Console.WriteLine("1. Yes, I'm in");
                Console.WriteLine("2. Not this time");
                String decisionToParticipate = Console.ReadLine();
                if (decisionToParticipate.Equals("1"))
                {
                    roulette.addPlayer(userList[i]);
                }
                else
                {
                }
            }
            rouletteOpening(idRoulette);
        }
        public bool rouletteOpening(int idRoulette)
        {
            bool successful = true;
            rouletteList[idRoulette].setStateRoulette(true);
            List<User> players = rouletteList[idRoulette].getPlayersInGame();
            for (int i = 0; i < players.Count(); i++)
            {
                int idUser = players[i].getUserId();
                Console.WriteLine("Player " + idUser + ": Which bet do you want to make?");
                Console.WriteLine("1. Bet on a number");
                Console.WriteLine("2. Bet on a color");
                String betType = Console.ReadLine();
                if (betType.Equals("1"))
                {
                }
                else
                {
                }
            }
            return successful;
        }
        public void rouletteClosing(int idRoulette)
        {
        }
    }
}
