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
        private void GameOver_Load(object sender, EventArgs e)
        {
            lblPlayedWords.Left = (ClientSize.Width - lblPlayedWords.Width) / 2;
            lblPlayedWords.Left = (ClientSize.Width - lblPlayedWords.Width) / 2;
        }

        public GameOver()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlayedWords_Click(object sender, EventArgs e)
        {

        }

        private void btnRematch_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveGame_Click(object sender, EventArgs e)
        {

        }
    }
}
