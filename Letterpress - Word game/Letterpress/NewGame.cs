using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LetterpressControl;

namespace Letterpress
{
    public partial class NewGame : Form
    {
        Thread thread;

        public NewGame()
        {
            InitializeComponent();
        }
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(OpenGameBoard);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenGameBoard()
        {
            Application.Run(new GameBoard());
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            LoadGame lg = new LoadGame();
            lg.ShowDialog();
            if (lg.storage.FileName != "")
                Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuGameNew_Click(object sender, EventArgs e)
        {
            btnNewGame_Click(sender, e);
        }

        private void mnuGameLoad_Click(object sender, EventArgs e)
        {
            btnLoadGame_Click(sender, e);
        }

        private void mnuGameExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuOptionStats_Click(object sender, EventArgs e)
        {
            Stats sts = new Stats();
            sts.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            btnNewGame.ForeColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255),
                                                  rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}