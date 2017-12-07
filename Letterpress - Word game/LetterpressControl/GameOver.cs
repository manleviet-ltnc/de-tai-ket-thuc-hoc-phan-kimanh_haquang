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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        int blue;
        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        int red;
        public int Red
        {
            get { return red; }
            set { red = value; }
        }

        public List<string> WordsListUsed = new List<string>();

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblScored.Left = (ClientSize.Width - lblScored.Width) / 2;

            if (Blue > Red)
                lblScored.Text = String.Format("Player Blue wins {0}-{1}",
                                                    Blue, Red);
            else
                lblScored.Text = String.Format("Player Red wins {0}-{1}",
                                                    Red, Blue);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlayedWords_Click(object sender, EventArgs e)
        {
            PlayedWords pw = new PlayedWords();
            pw.WordsListUsed = WordsListUsed;
            pw.Show();
        }

        private void btnRematch_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveGame_Click(object sender, EventArgs e)
        {

        }
    }
}
