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
        }
        public int CreateRoulette()
        {
            Roulette roulette = new Roulette();
            return roulette.getIdRoulette();
        }
        public bool rouletteOpening(int idRoulette)
        {
            bool successful = true;
            return successful;
        }
        public void rouletteClosing(int idRoulette)
        {
        }
    }
}
