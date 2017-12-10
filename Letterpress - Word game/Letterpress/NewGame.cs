using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LetterpressControl;

namespace Letterpress
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GameBoard gb = new GameBoard();
            Owner = gb;
            Hide();
            gb.Show();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GameBoard gb = new GameBoard();
            Owner = gb;
            Hide();
            gb.Show();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuOptionStats_Click(object sender, EventArgs e)
        {
            Stats sts = new Stats();
            sts.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int one = rnd.Next(0, 255);
            int two = rnd.Next(0, 255);
            int three = rnd.Next(0, 255);
            int four = rnd.Next(0, 255);

            btnGameStart.ForeColor = Color.FromArgb(one, two, three, four);
        }
    }
}