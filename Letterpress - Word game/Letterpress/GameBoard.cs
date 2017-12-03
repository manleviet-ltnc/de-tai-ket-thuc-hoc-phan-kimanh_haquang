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
        ProcessFile pf = new ProcessFile();
        Button[,] button = new Button[5, 5];
        List<string> wordsListUsed = new List<string>();

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

        Button btn;
        int index = -1;
        int[] row = new int[25];
        int[] column = new int[25];
        private void btnWord_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            txtWords.Text += btn.Text;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (btn == button[i, j])
                    {
                        index++;
                        row[index] = i;
                        column[index] = j;

                        AddPoint(sender, btn);
                        break;
                    }
            btn.Hide();

            btnClear.Show();
            btnBackspace.Show();
            btnOK.Show();
        }

        bool redTurn = false;
        int bluePoint;
        int redPoint;
        int point;
        int blueCount = 0;
        int redCount = 0;
        private void AddPoint(object sender, Button btn)
        {
            if (redTurn == false)
            {
                if (btn.BackColor == Color.LightSkyBlue)
                {
                    bluePoint--;
                    blueCount++;
                }

                if (btn.BackColor != Color.LightSkyBlue)
                {
                    if (btn.BackColor == Color.Red)
                    {
                        redPoint--;
                        redCount++;

                        lblRedPoint.Text = "" + redPoint;
                        Center();
                    }

                    if (lblBluePoint.Text == "")
                        lblBluePoint.Text = "1";
                    else
                    {
                        point = bluePoint + txtWords.Text.Length;
                        lblBluePoint.Text = "" + point;
                        Center();
                    }
                }
            }
            else
            {
                if (btn.BackColor == Color.Red)
                {
                    redPoint--;
                    redCount++;
                }

                if (btn.BackColor != Color.Red)
                {
                    if (btn.BackColor == Color.LightSkyBlue)
                    {
                        bluePoint--;
                        blueCount++;

                        lblBluePoint.Text = "" + bluePoint;
                        Center();
                    }

                    if (lblRedPoint.Text == "")
                        lblRedPoint.Text = "1";
                    else
                    {
                        point = redPoint + txtWords.Text.Length;
                        lblRedPoint.Text = "" + point;
                        Center();
                    }
                }
            }
        }

        private void SubtractPoint(Button[,] button)
        {
            if (redTurn == false)
            {
                if (btn.BackColor != Color.LightSkyBlue)
                {
                    if (btn.BackColor == Color.Red)
                    {
                        redPoint++;
                        int red = 0;

                        red = int.Parse(lblRedPoint.Text);
                        lblRedPoint.Text = "" + (red + 1);
                        Center();
                    }

                    point = bluePoint + txtWords.Text.Length;
                    lblBluePoint.Text = "" + point;
                    Center();
                }
            }
            else
            {
                if (btn.BackColor != Color.Red)
                {
                    if (btn.BackColor == Color.LightSkyBlue)
                    {
                        bluePoint++;
                        int blue = 0;

                        blue = int.Parse(lblBluePoint.Text);
                        lblBluePoint.Text = "" + (blue + 1);
                        Center();
                    }

                    point = redPoint + txtWords.Text.Length;
                    lblRedPoint.Text = "" + point;
                    Center();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SelectLiteral();
            txtWords.Clear();
            ShowButton();

            while (index >= 0)
            {
                button[row[index], column[index]].Show();
                index--;
            }

            if (redTurn == false)
            {
                if (btn.BackColor != Color.LightSkyBlue || redCount > 0)
                {
                    if (btn.BackColor == Color.Red || redCount > 0)
                    {
                        lblRedPoint.Text = "" + (redPoint + redCount);
                        Center();
                        redPoint = int.Parse(lblRedPoint.Text);

                        redCount = 0;
                    }
                }

                lblBluePoint.Text = "" + (bluePoint + blueCount);
                Center();

                if (blueCount > 0)
                {
                    bluePoint = int.Parse(lblBluePoint.Text);
                    blueCount = 0;
                }
            }
            else
            {
                if (btn.BackColor != Color.Red || blueCount > 0)
                {
                    if (btn.BackColor == Color.LightSkyBlue || blueCount > 0)
                    {
                        lblBluePoint.Text = "" + (bluePoint + blueCount);
                        Center();
                        bluePoint = int.Parse(lblBluePoint.Text);

                        blueCount = 0;
                    }
                }

                lblRedPoint.Text = "" + (redPoint + redCount);
                Center();

                if (redCount > 0)
                {
                    redPoint = int.Parse(lblRedPoint.Text);
                    redCount = 0;
                }
            }
        }

        private void ShowButton()
        {
            for (int i = 0; i < index + 1; i++)
                button[row[i], column[i]].Show();
        }

        int j = 0;
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pf.words.Length; i++)
                if (txtWords.Text == pf.words[i])
                {
                    if (j != 0)
                    {
                        foreach (string str in wordsListUsed)
                            if (pf.words[i] == str)
                            {
                                MessageBox.Show(pf.words[i].ToUpper() + " has already been played",
                                                "Already Used");
                                return;
                            }
                    }
                    wordsListUsed.Add(pf.words[i]);
                    j++;
                    break;
                }
                else if (pf.words[i] == pf.words[pf.words.Length - 1])
                    return;

            SelectLiteral();
            
            ShowButton();
            if (redTurn == false)
            {
                pbxBlueIndex.Hide();
                pbxRedIndex.Show();
            }
            else
            {
                pbxRedIndex.Hide();
                pbxBlueIndex.Show();
            }

            for (int i = 0; i <= index; i++)
            {
                if (redTurn == false)
                {
                    button[row[i], column[i]].BackColor = Color.LightSkyBlue;
                    if (i == index)
                    {
                        redTurn = true;
                        bluePoint = int.Parse(lblBluePoint.Text);

                        blueCount = 0;
                        redCount = 0;
                    }
                }
                else
                {
                    button[row[i], column[i]].BackColor = Color.Red;
                    if (i == index)
                    {
                        redTurn = false;
                        redPoint = int.Parse(lblRedPoint.Text);

                        blueCount = 0;
                        redCount = 0;
                    }
                }
            }

            txtWords.Clear();
            index = -1;

            int count = 25;
            foreach (Button b in button)
            {
                if (b.BackColor != Color.Gainsboro)
                    count--;
                if (count == 0)
                {
                    GameOver go = new GameOver();
                    go.Show();
                }
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtWords.Text != "")
            {
                txtWords.Text = txtWords.Text.Remove(txtWords.Text.Length - 1);
                button[row[index], column[index]].Show();
                index--;

                SubtractPoint(button);
            }

            if (txtWords.Text == "")
                SelectLiteral();
        }
    }
}