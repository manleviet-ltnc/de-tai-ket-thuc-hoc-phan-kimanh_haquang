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

        Button[] blue = new Button[25];
        Button[] red = new Button[25];
        int count1 =-1;
        int count2 = -1;
        int point = 0;
        bool redTurn = false;
        private void btnWord_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtWords.Text += btn.Text;
            btn.Hide();

            if (redTurn == false)
            {
                if (count1 > 23)
                    count1 = 0;
                else
                {
                    if (btn.BackColor != Color.LightSkyBlue)
                        count1++;
                }

                blue[count1] = btn;

                if (lblBluePoint.Text == "0")
                    lblBluePoint.Text = "1";
                else
                {
                    if (btn.BackColor != Color.LightSkyBlue)
                        point = count1 + 1;
                    lblBluePoint.Text = point + "";
                }
            }
            else
            {
                if (count2 > 23)
                    count2 = 0;
                else
                {
                    if (btn.BackColor != Color.Red)
                        count2++;
                }

                red[count2] = btn;

                if (lblRedPoint.Text == "0")
                    lblRedPoint.Text = "1";
                else
                {
                    if (btn.BackColor != Color.Red)
                        point = count2 + 1;
                    lblRedPoint.Text = point + "";
                }
            }

            btnClear.Show();
            btnBackspace.Show();
            btnOK.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PlayWords();
            txtWords.Clear();
            ShowButton();
        }

        private void ShowButton()
        {
            if (redTurn == false)
            {
                foreach (Button blueButton in blue)
                {
                    if (blueButton is null)
                        break;
                    blueButton.Show();
                }
            }
            else
            {
                foreach (Button redButton in red)
                {
                    if (redButton is null)
                        break;
                    redButton.Show();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
            if (pbxBlueIndex.Visible == true)
            {
                pbxBlueIndex.Hide();
                pbxRedIndex.Show();
            }
            else
            {
                pbxRedIndex.Hide();
                pbxBlueIndex.Show();
            }

            if (redTurn == false)
            {
                foreach (Button blueButton in blue)
                {
                    if (blueButton is null)
                        break;
                    blueButton.BackColor = Color.LightSkyBlue;
                }
                redTurn = true;
            }
            else
            {
                foreach (Button redButton in red)
                {
                    if (redButton is null)
                        break;
                    redButton.BackColor = Color.Red;
                }
                redTurn = false;
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtWords.Text != "")
            {
                txtWords.Text = txtWords.Text.Remove(txtWords.Text.Length - 1);

                
            }

            if (txtWords.Text == "")
                PlayWords();
        }
    }
}