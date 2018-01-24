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

        int bluePoint;
        public int BluePoint
        {
            get { return bluePoint; }
            set { bluePoint = value; }
        }

        int redPoint;
        public int RedPoint
        {
            get { return redPoint; }
            set { redPoint = value; }
        }

        public bool RedTurn = false;

        bool rematch;
        public bool Rematch
        {
            get { return rematch; }
            set { rematch = value; }
        }

        string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        int gameLoad;
        public int GameLoad
        {
            get { return gameLoad; }
            set { gameLoad = value; }
        }
    }
}