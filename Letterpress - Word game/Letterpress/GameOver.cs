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
using LetterpressManager;

namespace Letterpress
{
    public partial class GameOver : Form
    {
        Thread thread;
        Storage storage;

        public GameOver(Storage _storage)
        {
            InitializeComponent();
            storage = _storage;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblScored.Left = (ClientSize.Width - lblScored.Width) / 2;

            if (storage.BluePoint > storage.RedPoint)
                lblScored.Text = String.Format("Player Blue wins {0}-{1}",
                                                storage.BluePoint, storage.RedPoint);
            else
                lblScored.Text = String.Format("Player Red wins {0}-{1}",
                                                storage.RedPoint, storage.BluePoint);
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            Stats sts = new Stats();
            sts.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlayedWords_Click(object sender, EventArgs e)
        {
            PlayedWords pw = new PlayedWords();
            pw.wordsListUsed = storage.wordsListUsed;
            pw.Show();
        }

        private void btnRematch_Click(object sender, EventArgs e)
        {
            storage.Rematch = true;

            Close();
            thread = new Thread(OpenNewGameBoard);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenNewGameBoard()
        {
            Application.Run(new GameBoard());
        }
    }
}