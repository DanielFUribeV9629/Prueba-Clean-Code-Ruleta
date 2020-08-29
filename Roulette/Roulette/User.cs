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
        public User()
        {
            userId = 1;
            userName = "";
            userCredit = 0f;
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
