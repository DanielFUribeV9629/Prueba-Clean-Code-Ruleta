using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Roulette
    {
        private int idRoulette;
        private bool stateRoulette;
        public Roulette()
        {
            idRoulette = 1;
            stateRoulette = true;
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
