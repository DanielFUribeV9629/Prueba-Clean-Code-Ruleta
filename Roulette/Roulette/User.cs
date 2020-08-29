using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class User
    {
        private int userId;
        private string userName;
        private float userCredit;
        private List<string> userBets;
        private List<float> usersAmountsBets;
        public User()
        {
            userId = 1;
            userName = "";
            userCredit = 0f;
            userBets = new List<string>();
            usersAmountsBets = new List<float>();
        }
        public void addBet(string betInGame)
        {
            userBets.Add(betInGame);
        }
        public List<string> getBets()
        {
            return userBets;
        }
        public void addAmountOfBet(float amountToBet)
        {
            usersAmountsBets.Add(amountToBet);
        }
        public List<float> getAmountsOfBetsInGame()
        {
            return usersAmountsBets;
        }
        public int getUserId()
        {
            return userId;
        }
        public void setUserId(int userId)
        {
            this.userId = userId;
        }
        public string getUserName()
        {
            return userName;
        }
        public void setUserName(string userName)
        {
            this.userName = userName;
        }
        public float getUserCredit()
        {
            return userCredit;
        }
        public void setUserCredit(float userCredit)
        {
            this.userCredit = userCredit;
        }
    }
}
