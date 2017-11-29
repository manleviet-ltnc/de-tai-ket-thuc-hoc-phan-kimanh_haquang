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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            PlayWords();
            pbxRedIndex.Hide();
        }

        private void PlayWords()
        {
            btnClear.Hide();
            btnBackspace.Hide();
            btnOK.Hide();
        }


        Thread thread;
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(ReturnNewGame);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ReturnNewGame(object o)
        {
            Application.Run(new NewGame());
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            Option opt = new Option();
            opt.Show();
        }
    }
}