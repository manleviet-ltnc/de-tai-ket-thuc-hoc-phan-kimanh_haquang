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
using Letterpress.Properties;

namespace Letterpress
{
    public partial class GameBoard : Form
    {
        Thread thread;
        ProcessFile pf = new ProcessFile();
        Storage storage = new Storage();

        Button[,] button = new Button[5, 5];
        Button btn;
        bool hasChanged = true;   // Kiểm tra game có sự thay đổi so với lúc lưu không
        bool redTurn = false;   // Kiểm tra xem có phải đang là lượt của người chơi đỏ không
        int index = -1;   // Chỉ số vị trí của button được chọn
        int[] row = new int[25];   // Mảng các chỉ số dòng button được chọn
        int[] column = new int[25];   // Mảng các chỉ số cột button được chọn
        int blueCount = 0;   // Điểm bị trừ / nhớ tạm của người chơi xanh
        int redCount = 0;   // Điểm bị trừ / nhớ tạm của người chơi đỏ
        bool gameOver = false;   // Kiểm tra game đã kết thúc chưa

        public GameBoard()
        {
            InitializeComponent();
        }

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

            ReadLiteral();
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

        private void SelectLiteral()
        {
            btnClear.Hide();
            btnDelete.Hide();
            btnOK.Hide();
            btnPass.Show();
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            SelectLiteral();
            pbxRedIndex.Hide();
            buttonList();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            if (button[i, j].Focused && i > 0)
                            {
                                button[i - 1, j].Focus();
                                return true;
                            }
                            else if (button[0, 0].Focused)
                            {
                                if (txtWords.Text.Length > 0)
                                    btnClear.Focus();
                                else
                                    btnBack.Focus();
                            }
                            else if (button[0, 4].Focused)
                            {
                                if (txtWords.Text.Length > 0)
                                    btnOK.Focus();
                                else
                                    btnPass.Focus();
                            }
                            else if (button[0, 1].Focused || button[0, 3].Focused)
                                return true;
                            else if (button[0, 2].Focused)
                            {
                                if (txtWords.Text.Length > 0)
                                    btn.Focus();
                                else
                                    return true;
                            }

                    if (btnPass.Focused || btnBack.Focused ||
                        btnOK.Focused || btnDelete.Focused || btnClear.Focused)
                        return true;

                    break;
                case Keys.Down:
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                        {
                            if (button[i, j].Focused && i < 4)
                            {
                                button[i + 1, j].Focus();
                                return true;
                            }
                        }

                    if (btnPass.Focused || btnOK.Focused)
                    {
                        button[0, 4].Focus();
                        return true;
                    }
                    else if (btnBack.Focused || btnClear.Focused)
                    {
                        button[0, 0].Focus();
                        return true;
                    }

                    break;
                case Keys.Right:
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            if (button[i, j].Focused)
                            {
                                if (j < 4)
                                    button[i, j + 1].Focus();
                                return true;
                            }

                    if (btnPass.Focused || btnOK.Focused)
                        return true;
                    else if (btnBack.Focused)
                    {
                        btnPass.Focus();
                        return true;
                    }
                    else if (btnClear.Focused)
                    {
                        btnDelete.Focus();
                        return true;
                    }
                    else if (btnDelete.Focused)
                    {
                        btnOK.Focus();
                        return true;
                    }

                    break;
                case Keys.Left:
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            if (button[i, j].Focused)
                            {
                                if (j > 0)
                                    button[i, j - 1].Focus();
                                return true;
                            }

                    if (btnBack.Focused || btnClear.Focused)
                        return true;
                    else if (btnPass.Focused)
                    {
                        btnBack.Focus();
                        return true;
                    }
                    else if (btnOK.Focused)
                    {
                        btnDelete.Focus();
                        return true;
                    }
                    else if (btnDelete.Focused)
                    {
                        btnClear.Focus();
                        return true;
                    }

                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(OpenNewGame);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenNewGame()
        {
            Application.Run(new NewGame());
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (gameOver)
                return;

            hasChanged = true;
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
            if (redTurn == false)
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
            if (redTurn == false)
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
            if (redTurn == false)
            {
                redTurn = true;
                pbxBlueIndex.Hide();
                pbxRedIndex.Show();
            }
            else
            {
                redTurn = false;
                pbxRedIndex.Hide();
                pbxBlueIndex.Show();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pf.words.Length; i++)
                if (txtWords.Text == pf.words[i])
                {
                    foreach (string str in storage.wordsListUsed)
                        if (txtWords.Text == str)
                        {
                            MessageBox.Show(str.ToUpper() + " has already been played",
                                            "Already Used");
                            return;
                        }

                    storage.wordsListUsed.Add(pf.words[i]);
                    break;
                }
                else if (pf.words[i] == pf.words[pf.words.Length - 1])
                    return;

            SelectLiteral();
            ShowButton();

            for (int i = 0; i <= index; i++)
            {
                if (redTurn == false)
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

            if (storage.BluePoint + storage.RedPoint == 25)
            {
                hasChanged = false;
                GameOver go = new GameOver(storage);
                go.ShowDialog();

                gameOver = true;
                if (storage.Rematch)
                    Close();
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
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
            if (gameOver)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to pass your turn?",
                                                  "", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                hasChanged = true;

                redTurn = !redTurn;
                if (redTurn)
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

        private void mnuGameLoadGame_Click(object sender, EventArgs e)
        {
            hasChanged = false;
            storage.BluePoint = Settings.Default.bluePoint;
            lblBluePoint.Text = "" + storage.BluePoint;
            storage.RedPoint = Settings.Default.redPoint;
            lblRedPoint.Text = "" + storage.RedPoint;

            pbxBlueIndex.Visible = Settings.Default.blueIndex;
            pbxRedIndex.Visible = Settings.Default.redIndex;
            redTurn = pbxRedIndex.Visible;

            button[0, 0].Text = Settings.Default.text00;
            button[0, 1].Text = Settings.Default.text01;
            button[0, 2].Text = Settings.Default.text02;
            button[0, 3].Text = Settings.Default.text03;
            button[0, 4].Text = Settings.Default.text04;
            button[1, 0].Text = Settings.Default.text10;
            button[1, 1].Text = Settings.Default.text11;
            button[1, 2].Text = Settings.Default.text12;
            button[1, 3].Text = Settings.Default.text13;
            button[1, 4].Text = Settings.Default.text14;
            button[2, 0].Text = Settings.Default.text20;
            button[2, 1].Text = Settings.Default.text21;
            button[2, 2].Text = Settings.Default.text22;
            button[2, 3].Text = Settings.Default.text23;
            button[2, 4].Text = Settings.Default.text24;
            button[3, 0].Text = Settings.Default.text30;
            button[3, 1].Text = Settings.Default.text31;
            button[3, 2].Text = Settings.Default.text32;
            button[3, 3].Text = Settings.Default.text33;
            button[3, 4].Text = Settings.Default.text34;
            button[4, 0].Text = Settings.Default.text40;
            button[4, 1].Text = Settings.Default.text41;
            button[4, 2].Text = Settings.Default.text42;
            button[4, 3].Text = Settings.Default.text43;
            button[4, 4].Text = Settings.Default.text44;

            button[0, 0].BackColor = Settings.Default.color00;
            button[0, 1].BackColor = Settings.Default.color01;
            button[0, 2].BackColor = Settings.Default.color02;
            button[0, 3].BackColor = Settings.Default.color03;
            button[0, 4].BackColor = Settings.Default.color04;
            button[1, 0].BackColor = Settings.Default.color10;
            button[1, 1].BackColor = Settings.Default.color11;
            button[1, 2].BackColor = Settings.Default.color12;
            button[1, 3].BackColor = Settings.Default.color13;
            button[1, 4].BackColor = Settings.Default.color14;
            button[2, 0].BackColor = Settings.Default.color20;
            button[2, 1].BackColor = Settings.Default.color21;
            button[2, 2].BackColor = Settings.Default.color22;
            button[2, 3].BackColor = Settings.Default.color23;
            button[2, 4].BackColor = Settings.Default.color24;
            button[3, 0].BackColor = Settings.Default.color30;
            button[3, 1].BackColor = Settings.Default.color31;
            button[3, 2].BackColor = Settings.Default.color32;
            button[3, 3].BackColor = Settings.Default.color33;
            button[3, 4].BackColor = Settings.Default.color34;
            button[4, 0].BackColor = Settings.Default.color40;
            button[4, 1].BackColor = Settings.Default.color41;
            button[4, 2].BackColor = Settings.Default.color42;
            button[4, 3].BackColor = Settings.Default.color43;
            button[4, 4].BackColor = Settings.Default.color44;

            storage.wordsListUsed = Settings.Default.wordsListUsed;
        }

        private void mnuGameSaveGame_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (gameOver)
                return;

            hasChanged = false;
            Settings.Default.bluePoint = storage.BluePoint;
            Settings.Default.redPoint = storage.RedPoint;

            if (redTurn == false)
            {
                Settings.Default.blueIndex = true;
                Settings.Default.redIndex = false;
            }
            else
            {
                Settings.Default.blueIndex = false;
                Settings.Default.redIndex = true;
            }

            Settings.Default.text00 = button[0, 0].Text;
            Settings.Default.text01 = button[0, 1].Text;
            Settings.Default.text02 = button[0, 2].Text;
            Settings.Default.text03 = button[0, 3].Text;
            Settings.Default.text04 = button[0, 4].Text;
            Settings.Default.text10 = button[1, 0].Text;
            Settings.Default.text11 = button[1, 1].Text;
            Settings.Default.text12 = button[1, 2].Text;
            Settings.Default.text13 = button[1, 3].Text;
            Settings.Default.text14 = button[1, 4].Text;
            Settings.Default.text20 = button[2, 0].Text;
            Settings.Default.text21 = button[2, 1].Text;
            Settings.Default.text22 = button[2, 2].Text;
            Settings.Default.text23 = button[2, 3].Text;
            Settings.Default.text24 = button[2, 4].Text;
            Settings.Default.text30 = button[3, 0].Text;
            Settings.Default.text31 = button[3, 1].Text;
            Settings.Default.text32 = button[3, 2].Text;
            Settings.Default.text33 = button[3, 3].Text;
            Settings.Default.text34 = button[3, 4].Text;
            Settings.Default.text40 = button[4, 0].Text;
            Settings.Default.text41 = button[4, 1].Text;
            Settings.Default.text42 = button[4, 2].Text;
            Settings.Default.text43 = button[4, 3].Text;
            Settings.Default.text44 = button[4, 4].Text;

            Settings.Default.color00 = button[0, 0].BackColor;
            Settings.Default.color01 = button[0, 1].BackColor;
            Settings.Default.color02 = button[0, 2].BackColor;
            Settings.Default.color03 = button[0, 3].BackColor;
            Settings.Default.color04 = button[0, 4].BackColor;
            Settings.Default.color10 = button[1, 0].BackColor;
            Settings.Default.color11 = button[1, 1].BackColor;
            Settings.Default.color12 = button[1, 2].BackColor;
            Settings.Default.color13 = button[1, 3].BackColor;
            Settings.Default.color14 = button[1, 4].BackColor;
            Settings.Default.color20 = button[2, 0].BackColor;
            Settings.Default.color21 = button[2, 1].BackColor;
            Settings.Default.color22 = button[2, 2].BackColor;
            Settings.Default.color23 = button[2, 3].BackColor;
            Settings.Default.color24 = button[2, 4].BackColor;
            Settings.Default.color30 = button[3, 0].BackColor;
            Settings.Default.color31 = button[3, 1].BackColor;
            Settings.Default.color32 = button[3, 2].BackColor;
            Settings.Default.color33 = button[3, 3].BackColor;
            Settings.Default.color34 = button[3, 4].BackColor;
            Settings.Default.color40 = button[4, 0].BackColor;
            Settings.Default.color41 = button[4, 1].BackColor;
            Settings.Default.color42 = button[4, 2].BackColor;
            Settings.Default.color43 = button[4, 3].BackColor;
            Settings.Default.color44 = button[4, 4].BackColor;

            Settings.Default.wordsListUsed = storage.wordsListUsed;
            Settings.Default.Save();
        }

        private void mnuOptionPlayedWords_Click(object sender, EventArgs e)
        {
            PlayedWords pw = new PlayedWords();
            pw.wordsListUsed = storage.wordsListUsed;
            pw.ShowDialog();
        }

        private void mnuOptionResignGame_Click(object sender, EventArgs e)
        {
            if (gameOver)
                PlayNewBoard();
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to resign the game?",
                                                      "", MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    PlayNewBoard();
            }
        }

        private void PlayNewBoard()
        {
            Close();
            thread = new Thread(OpenNewGameBoard);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void OpenNewGameBoard()
        {
            Application.Run(new GameBoard());
        }

        private void mnuOptionStats_Click(object sender, EventArgs e)
        {
            Stats sts = null;
            if (gameOver)
                sts = new Stats(storage);
            else
                sts = new Stats();
            sts.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (hasChanged)
            {
                DialogResult result = MessageBox.Show("Are you want to save this game?", "",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Save();
                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}