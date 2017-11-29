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
using System.IO;
using LetterpressControl;

namespace Letterpress
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }

        Thread thread;
        private void Control_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(OpenMain);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenMain(object o)
        {
            Application.Run(new Main());
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            pnlNewGame.BackColor = Color.LightSkyBlue;
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            pnlNewGame.BackColor = Color.White;
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            Stats sts = new Stats();
            sts.Show();
        }
    }
}