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
    public partial class Main : Form
    {
        Thread thread;
        ProcessFile pf = new ProcessFile();
        Storage storage = new Storage();

        Button[,] button = new Button[5, 5];
        Button btn;
        int index = -1;
        int[] row = new int[25];   // Mảng các chỉ số dòng button được chọn
        int[] column = new int[25];   // Mảng các chỉ số cột button được chọn
        int blueCount = 0;   // Điểm bị trừ của người chơi xanh
        int redCount = 0;   // Điểm bị trừ của người chơi đỏ
        int count = 0;

        private void Center()
        {
            lblBluePoint.Left = (pnlBluePoint.Width - lblBluePoint.Width) / 2;
            lblRedPoint.Left = (pnlRedPoint.Width - lblRedPoint.Width) / 2;
        }

        private void buttonList()
        {
            button[0, 0] = btn00;
            button[0, 1] = btn01;
            button[0, 2] = btn02;
            button[0, 3] = btn03;
            button[0, 4] = btn04;
            button[1, 0] = btn10;
            button[1, 1] = btn11;
            button[1, 2] = btn12;
            button[1, 3] = btn13;
            button[1, 4] = btn14;
            button[2, 0] = btn20;
            button[2, 1] = btn21;
            button[2, 2] = btn22;
            button[2, 3] = btn23;
            button[2, 4] = btn24;
            button[3, 0] = btn30;
            button[3, 1] = btn31;
            button[3, 2] = btn32;
            button[3, 3] = btn33;
            button[3, 4] = btn34;
            button[4, 0] = btn40;
            button[4, 1] = btn41;
            button[4, 2] = btn42;
            button[4, 3] = btn43;
            button[4, 4] = btn44;
        }

        private void ReadLiteral()
        {
            pf.ReadData();
            pf.RandomLiteral();
            int index = pf.wordsList.Length - 1;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    button[i, j].Text = pf.wordsList[index];
                    index--;
                }
        }

        public Main()
        {
            InitializeComponent();

            SelectLiteral();
            pbxRedIndex.Hide();
            buttonList();
            ReadLiteral();
        }

        private void SelectLiteral()
        {
            btnClear.Hide();
            btnDelete.Hide();
            btnOK.Hide();
            btnPass.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to save this game?", "",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Close();
                thread = new Thread(OpenNewGame);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else if (result == DialogResult.No)
            {
                Close();
                thread = new Thread(OpenNewGame);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void OpenNewGame(object o)
        {
            Application.Run(new NewGame());
        }
        
        private void btnWord_Click(object sender, EventArgs e)
        {
            storage.HasChanged = true;
            btn = (Button)sender;
            txtWords.Text += btn.Text;

            btn.Hide();
            btnPass.Hide();
            btnClear.Show();
            btnDelete.Show();
            btnOK.Show();

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (btn == button[i, j])
                    {
                        index++;
                        row[index] = i;
                        column[index] = j;

                        AddPoint(btn);
                        Center();
                        return;
                    }
        }
        
        private void AddPoint(Button btn)
        {
            if (storage.RedTurn == false)
            {
                if (btn.BackColor == Color.LightSkyBlue)
                    blueCount++;
                else
                {
                    if (btn.BackColor == Color.Red)
                    {
                        redCount++;
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount);
                    }

                    if (lblBluePoint.Text == "")
                        lblBluePoint.Text = "1";
                    else
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount + txtWords.Text.Length);
                }
            }
            else
            {
                if (btn.BackColor == Color.Red)
                    redCount++;
                else
                {
                    if (btn.BackColor == Color.LightSkyBlue)
                    {
                        blueCount++;
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount);
                    }

                    if (lblRedPoint.Text == "")
                        lblRedPoint.Text = "1";
                    else
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount + txtWords.Text.Length);
                }
            }
        }

        private void SubtractPoint(Button[,] btn)
        {
            if (storage.RedTurn == false)
            {
                if (btn[row[index], column[index]].BackColor != Color.LightSkyBlue)
                {
                    if (btn[row[index], column[index]].BackColor == Color.Red)
                    {
                        redCount--;
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount);
                    }

                    lblBluePoint.Text = "" + (storage.BluePoint - blueCount + txtWords.Text.Length);
                }
                else
                    blueCount--;
            }
            else
            {
                if (btn[row[index], column[index]].BackColor != Color.Red)
                {
                    if (btn[row[index], column[index]].BackColor == Color.LightSkyBlue)
                    {
                        blueCount--;
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount);
                    }

                    lblRedPoint.Text = "" + (storage.RedPoint - redCount + txtWords.Text.Length);
                }
                else
                    redCount--;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            storage.HasChanged = true;
            SelectLiteral();
            txtWords.Clear();
            ShowButton();

            while (index >= 0)
            {
                button[row[index], column[index]].Show();
                index--;
            }

            if (storage.RedTurn == false)
            {
                if (btn.BackColor != Color.LightSkyBlue)
                {
                    if (redCount > 0)
                    {
                        lblRedPoint.Text = "" + storage.RedPoint;
                        redCount = 0;
                    }
                }

                lblBluePoint.Text = "" + storage.BluePoint;
                blueCount = 0;
            }
            else
            {
                if (btn.BackColor != Color.Red)
                {
                    if (blueCount > 0)
                    {
                        lblBluePoint.Text = "" + storage.BluePoint;
                        blueCount = 0;                      
                    }
                }

                lblRedPoint.Text = "" + storage.RedPoint;
                redCount = 0;
            }

            Center();
        }

        private void ShowButton()
        {
            for (int i = 0; i < index + 1; i++)
                button[row[i], column[i]].Show();
        }

        private void ChangeTurn(Storage storage)
        {
            if (storage.RedTurn == false)
            {
                storage.RedTurn = true;
                pbxBlueIndex.Hide();
                pbxRedIndex.Show();
            }
            else
            {
                storage.RedTurn = false;
                pbxRedIndex.Hide();
                pbxBlueIndex.Show();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < pf.words.Length; i++)
                if (txtWords.Text == pf.words[i])
                {
                    if (j != 0)
                    {
                        foreach (string str in storage.wordsListUsed)
                            if (pf.words[i] == str)
                            {
                                MessageBox.Show(pf.words[i].ToUpper() + " has already been played",
                                                "Already Used");
                                return;
                            }
                    }

                    storage.wordsListUsed.Add(pf.words[i]);
                    j++;
                    break;
                }
                else if (pf.words[i] == pf.words[pf.words.Length - 1])
                    return;

            SelectLiteral();
            ShowButton();

            for (int i = 0; i <= index; i++)
            {
                if (storage.RedTurn == false)
                    button[row[i], column[i]].BackColor = Color.LightSkyBlue;
                else
                    button[row[i], column[i]].BackColor = Color.Red;
            }

            ChangeTurn(storage);

            storage.BluePoint = int.Parse(lblBluePoint.Text);
            storage.RedPoint = int.Parse(lblRedPoint.Text);

            txtWords.Clear();
            blueCount = 0;
            redCount = 0;
            index = -1;
            j = 0;

            count = 25;
            FinishGame(count);
        }

        private void FinishGame(int count)
        {
            foreach(Button b in button)
            {
                if (b.BackColor != Color.Gainsboro)
                    count--;
                if (count == 0)
                {
                    GameOver go = new GameOver();
                    go.Blue = storage.BluePoint;
                    go.Red = storage.RedPoint;
                    go.WordsListUsed = storage.wordsListUsed;
                    go.Show();
                }
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            storage.HasChanged = true;
            if (txtWords.Text != "")
            {
                txtWords.Text = txtWords.Text.Remove(txtWords.Text.Length - 1);
                button[row[index], column[index]].Show();
                SubtractPoint(button);
                index--;
            }

            if (txtWords.Text == "")
                SelectLiteral();

            Center();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to pass your turn?",
                                                  "", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                storage.RedTurn = !storage.RedTurn;
                if (storage.RedTurn)
                {
                    pbxBlueIndex.Hide();
                    pbxRedIndex.Show();
                }
                else
                {
                    pbxRedIndex.Hide();
                    pbxBlueIndex.Show();
                }
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            storage.HasChanged = false;

        }

        private void mnuOptionPlayedWords_Click(object sender, EventArgs e)
        {
            PlayedWords pw = new PlayedWords();
            pw.WordsListUsed = storage.wordsListUsed;
            pw.Show();
        }

        private void mnuOptionResignGame_Click(object sender, EventArgs e)
        {

        }

        private void mnuOptionStats_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (storage.HasChanged)
            {
                DialogResult result = MessageBox.Show("Are you want to save this game?", "",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    Close();
                }
                else if (result == DialogResult.No)
                {
                    Close();
                }
            }
        }
    }
}