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

        private bool rematch;
        public bool Rematch
        {
            get { return rematch; }
            set { rematch = value; }
        }
    }
}