using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LetterpressManager;

namespace LetterpressControl
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
        }

        Storage storage = new Storage();

        private void Stats_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
