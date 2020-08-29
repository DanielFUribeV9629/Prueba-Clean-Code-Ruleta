using System.Collections.Generic;

namespace Roulette
{
    class Roulette
    {
        private int idRoulette;
        private bool stateRoulette;
        private List<User> usersPlaying;
        public Roulette()
        {
            idRoulette = 1;
            stateRoulette = true;
            usersPlaying = new List<User>();
        }
        public void addPlayer(User user)
        {
            usersPlaying.Add(user);
        }
        public List<User> getPlayersInGame()
        {
            return usersPlaying;
        }
        public int getIdRoulette()
        {
            return idRoulette;
        }
        public void setIdRoulette(int idRoulette)
        {
            this.idRoulette = idRoulette;
        }
        public bool getStateRoulette()
        {
            return stateRoulette;
        }
        public void setStateRoulette(bool stateRoulette)
        {
            this.stateRoulette = stateRoulette;
        }
    }
}
