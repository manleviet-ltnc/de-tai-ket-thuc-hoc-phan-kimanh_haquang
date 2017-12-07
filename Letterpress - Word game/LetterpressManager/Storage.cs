using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterpressManager
{
    public class Storage
    {
        public List<string> wordsListUsed = new List<string>();

        private bool redTurn = false;
        public bool RedTurn
        {
            get { return redTurn; }
            set { redTurn = value; }
        }
    }
}