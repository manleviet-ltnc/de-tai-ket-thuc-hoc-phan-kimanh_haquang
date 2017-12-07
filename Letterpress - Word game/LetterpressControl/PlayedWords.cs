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
    public partial class PlayedWords : Form
    {
        public PlayedWords()
        {
            InitializeComponent();
        }

        public List<string> WordsListUsed = new List<string>();

        private void PlayedWords_Load(object sender, EventArgs e)
        {
            lblTotalPlayedWords.Text = String.Format(WordsListUsed.Count + " {0}", WordsListUsed.Count >= 0 && WordsListUsed.Count < 2 ? "Played Word" : "Played Words");
            lblTotalPlayedWords.Left = (ClientSize.Width - lblTotalPlayedWords.Width) / 2;

            lblPlayedWords.Text += "\n";
            for (int i = 0; i < WordsListUsed.Count; i++)
            {
                lblPlayedWords.Text += WordsListUsed[i].ToUpper();
                if (i != WordsListUsed.Count - 1)
                    lblPlayedWords.Text += ", ";
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
