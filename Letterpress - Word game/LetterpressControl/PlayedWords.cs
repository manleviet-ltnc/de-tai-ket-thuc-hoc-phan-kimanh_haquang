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
        public List<string> wordsListUsed = new List<string>();

        public PlayedWords()
        {
            InitializeComponent();
        }

        private void PlayedWords_Load(object sender, EventArgs e)
        {
            lblTotalPlayedWords.Text = String.Format(wordsListUsed.Count + " {0}", wordsListUsed.Count >= 0 && wordsListUsed.Count < 2 ? "Played Word" : "Played Words");
            lblTotalPlayedWords.Left = (ClientSize.Width - lblTotalPlayedWords.Width) / 2;

            lblPlayedWords.Text += "\n";
            for (int i = 0; i < wordsListUsed.Count; i++)
            {
                lblPlayedWords.Text += wordsListUsed[i].ToUpper();
                if (i != wordsListUsed.Count - 1)
                    lblPlayedWords.Text += ", ";
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
