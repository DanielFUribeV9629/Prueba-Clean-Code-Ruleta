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
                    successful = BetTypeNumber(idRoulette, idUser);
                }
                else
                {
                    successful = BetTypeColor(idRoulette, idUser);
                }
            }
            return successful;
        }
        public void rouletteClosing(int idRoulette)
        {
        }
        public bool BetTypeNumber(int idRoulette, int idUser)
        {
            Console.WriteLine("Player: " + idUser + " Choose a number to do a bet between 0-36");
            String chosenNumberToBet = Console.ReadLine();
            int numberToBet = int.Parse(chosenNumberToBet);
            if (numberToBet >= 0 && numberToBet <= 36)
            {
                Console.WriteLine("How much is the bet for this number?");
                string chosenAmountToBet = Console.ReadLine();
                float amountToBet = float.Parse(chosenAmountToBet);
                bool validBet = CreditValidation(amountToBet, idUser);
                if (validBet)
                {                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool BetTypeColor(int idRoulette, int idUser)
        {
            Console.WriteLine("Player: " + idUser + " Choose red or black color to do a bet");
            Console.WriteLine("1. Bet red color");
            Console.WriteLine("2. Bet black color");
            String chosenColor = Console.ReadLine();
            string colorForBet = toBetOnAColor(chosenColor);
            string chosenAmountToBet = Console.ReadLine();
            float amountToBet = float.Parse(chosenAmountToBet);
            bool validBet = CreditValidation(amountToBet, idUser);
            if (validBet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreditValidation(float amountToBet, int idUser)
        {
            float userCredit = userList[idUser].getUserCredit();
            if (userCredit > amountToBet)
            {
                userCredit = userCredit - amountToBet;
                userList[idUser].setUserCredit(userCredit);
                return true;
            }
            return false;
        }
        public string toBetOnAColor(string chosenColor)
        {
            if (chosenColor == "1")
            {
                chosenColor = "red";
            }
            else
            {
                chosenColor = "black";
            }
            Console.WriteLine("How much is the bet for " + chosenColor + " color?");
            return chosenColor;
        }
    }
}
