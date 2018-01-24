using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using LetterpressManager;

namespace Letterpress
{
    public partial class LoadGame : Form
    {
        Thread thread;
        public Storage storage = new Storage();
        public List<string> gameSaved = new List<string>();
        bool openFromMenu;

        public LoadGame()
        {
            InitializeComponent();
            openFromMenu = true;
        }

        public LoadGame(Storage _storage)
        {
            InitializeComponent();
            storage = _storage;
        }

        private void LoadGame_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("game saved.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                gameSaved.Add(line);
                lstGameSaved.Items.Add(line);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (lstGameSaved.SelectedIndex != -1)
            {
                storage.FileName = lstGameSaved.Items[lstGameSaved.SelectedIndex].ToString();
                storage.GameLoad = lstGameSaved.SelectedIndex;

                if (openFromMenu)
                {
                    Close();
                    thread = new Thread(OpenGameBoard);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    return;
                }

                Close();
            }
        }

        private void OpenGameBoard()
        {
            Application.Run(new GameBoard(storage));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            storage.FileName = "";
            Close();
        }
    }
}
