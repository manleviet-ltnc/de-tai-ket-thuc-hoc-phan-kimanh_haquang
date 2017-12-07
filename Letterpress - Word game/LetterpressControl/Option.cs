using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetterpressControl
{
    public partial class Option : Form
    {
        public Option()
        {
            InitializeComponent();
        }

        public List<string> WordsListUsed = new List<string>();

        private void btnPlayedWords_Click(object sender, EventArgs e)
        {
            PlayedWords pw = new PlayedWords();
            pw.WordsListUsed = WordsListUsed;
            pw.Show();
        }

        private void btnNewBoard_Click(object sender, EventArgs e)
        {
            NewBoard nb = new NewBoard();
            nb.Show();
        }

        private void btnResignGame_Click(object sender, EventArgs e)
        {
            ResignGame rg = new ResignGame();
            rg.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
