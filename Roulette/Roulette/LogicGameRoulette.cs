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
                Console.WriteLine("Player " + userList[i].getUserId() + ": Are you going to play? \n 1. Yes, I'm in \n 2. Not this time");                
                String decisionToParticipate = Console.ReadLine();
                if (decisionToParticipate.Equals("1"))
                {
                    roulette.addPlayer(userList[i]);
                }
                else
                {
                    userList[i].addAmountOfBet(0f);
                    userList[i].addBet("");
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
                Console.WriteLine("Player " + idUser + ": Which bet do you want to make? \n 1. Bet on a number \n 2. Bet on a color");                
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
            Random random = new Random();
            List<User> players = rouletteList[idRoulette].getPlayersInGame();
            int winningNumber = random.Next(0, 37);
            string winningColor;
            if (winningNumber % 2 == 0)
            {
                winningColor = "red";
            }
            else
            {
                winningColor = "black";
            }
            string winningBet = winningNumber.ToString();
            Console.WriteLine("The number " + winningNumber + " and the color " + winningColor + " are the ones that win the bet \n -------------------------------------------");
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].getBets()[idRoulette].Equals(winningBet) || players[i].getBets()[idRoulette].Equals(winningColor))
                {
                    Console.WriteLine("Player " + players[i].getUserId() + ": wins the bet");
                    float actualCreditOfUser = creditWinAfterBet(players[i], idRoulette, winningBet);
                    Console.WriteLine("Player " + players[i].getUserId() + ": have " + actualCreditOfUser + " dollars ");
                }
                else
                {
                    Console.WriteLine("Player " + players[i].getUserId() + ": loses the bet");
                    float actualCreditOfUser = players[i].getUserCredit();
                    Console.WriteLine("Player " + players[i].getUserId() + ": have " + actualCreditOfUser + " dollars ");
                }
            }
            rouletteList[idRoulette].setStateRoulette(false);
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
                    BetOnANumber(idRoulette, idUser, chosenNumberToBet, amountToBet);
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
            Console.WriteLine("Player: " + idUser + " Choose red or black color to do a bet \n 1. Bet red color \n 2. Bet black color");            
            String chosenColor = Console.ReadLine();
            string colorForBet = toBetOnAColor(chosenColor);
            string chosenAmountToBet = Console.ReadLine();
            float amountToBet = float.Parse(chosenAmountToBet);
            bool validBet = CreditValidation(amountToBet, idUser);
            if (validBet)
            {
                BetOnAColor(idRoulette, idUser, colorForBet, amountToBet);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void BetOnANumber(int idRoulette, int idUser, string numberToBet, float amountToBet)
        {
            userList[idUser].addAmountOfBet(amountToBet);
            userList[idUser].addBet(numberToBet);
        }
        public void BetOnAColor(int idRoulette, int idUser, string colorToBet, float amountToBet)
        {
            userList[idUser].addAmountOfBet(amountToBet);
            userList[idUser].addBet(colorToBet);
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
        public float creditWinAfterBet(User user, int idRoulette, string betWinWithNumber)
        {
            List<float> amountOfBet = user.getAmountsOfBetsInGame();
            float creditAfterWinningABet;
            if (user.getBets()[idRoulette].Equals(betWinWithNumber))
            {
                creditAfterWinningABet = user.getUserCredit() + (amountOfBet[idRoulette] * 3.1f);
                user.setUserCredit(creditAfterWinningABet);
            }
            else
            {
                creditAfterWinningABet = user.getUserCredit() + (amountOfBet[idRoulette] * 1.3f);
                user.setUserCredit(creditAfterWinningABet);
            }
            Console.WriteLine("The player won with the bet: " + user.getBets()[idRoulette]);
            return creditAfterWinningABet;
        }
        public void viewCreatedRoulettes()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Roulettes and states");
            for (int i = 0; i < rouletteList.Count(); i++)
            {
                if (rouletteList[i].getStateRoulette() == true)
                {
                    Console.WriteLine("Roulette: " + rouletteList[i].getIdRoulette());
                    Console.WriteLine("State of Roulette: Abierta");
                }
                else
                {
                    Console.WriteLine("Roulette: " + rouletteList[i].getIdRoulette());
                    Console.WriteLine("State of Roulette: Cerrada");
                }
            }
        }
        public void viewBetsOfUsers()
        {
            for (int i = 0; i < userList.Count(); i++)
            {
                for (int j = 0; j < userList[i].getBets().Count(); j++)
                {
                    Console.WriteLine("User: " + userList[i].getBets()[j]);
                }
            }
        }
    }
}
