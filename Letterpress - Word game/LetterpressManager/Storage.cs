using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterpressManager
{
    public class Storage
    {
        private bool hasChanged = true;
        public bool HasChanged
        {
            get { return hasChanged; }
            set { hasChanged = value; }
        }

        public List<string> wordsListUsed = new List<string>();

        private bool redTurn = false;
        public bool RedTurn
        {
            get { return redTurn; }
            set { redTurn = value; }
        }

        private int bluePoint;
        public int BluePoint
        {
            get { return bluePoint; }
            set { bluePoint = value; }
        }

        private int redPoint;
        public int RedPoint
        {
            get { return redPoint; }
            set { redPoint = value; }
        }
    }
}