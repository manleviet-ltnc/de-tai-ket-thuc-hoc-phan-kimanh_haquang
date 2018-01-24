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
using LetterpressManager;

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
        int index = -1;   // Chỉ số vị trí của button được chọn
        int[] row = new int[25];   // Mảng các chỉ số dòng button được chọn
        int[] column = new int[25];   // Mảng các chỉ số cột button được chọn
        int blueCount = 0;   // Điểm bị trừ / nhớ tạm của người chơi xanh
        int redCount = 0;   // Điểm bị trừ / nhớ tạm của người chơi đỏ
        bool gameOver = false;   // Kiểm tra game đã kết thúc chưa
        List<string> gameSaved = new List<string>();   // Danh sách các game đã lưu
        bool hasLoaded = false;

        public GameBoard()
        {
            InitializeComponent();
        }

        public GameBoard(Storage _storage)
        {
            InitializeComponent();
            storage = _storage;

            SelectLiteral();
            buttonList();
            LoadGame();
            hasLoaded = true;
            hasChanged = false;
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
            // Đọc vào các từ
            pf.ReadData();

            // Tách các ký tự trong mỗi từ
            pf.RandomLiteral();

            int index = pf.wordsList.Length - 1;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    // Gán các kí tự được chọn ngẫu nhiên vào các button
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
            if (hasLoaded == false)
            {
                SelectLiteral();
                pbxRedIndex.Hide();
                buttonList();

                LoadGameList();
            }
            else
                LoadGameList();
        }

        private void LoadGameList()
        {
            StreamReader sr = new StreamReader("game saved.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
                gameSaved.Add(line);
            sr.Close();
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

                    if (button[0, 0].Focused)
                    {
                        if (txtWords.Text.Length > 0)
                            btnClear.Focus();
                        else
                            btnBack.Focus();
                        return true;
                    }

                    if (button[0, 4].Focused)
                    {
                        if (txtWords.Text.Length > 0)
                            btnOK.Focus();
                        else
                            btnPass.Focus();
                        return true;
                    }

                    if (button[0, 1].Focused || button[0, 3].Focused)
                        return true;

                    if (button[0, 2].Focused)
                    {
                        if (txtWords.Text.Length > 0)
                            btnDelete.Focus();
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
                            if (button[i, j].Focused && i <= 4)
                            {
                                if (i != 4)
                                    button[i + 1, j].Focus();
                                return true;
                            }
                        }

                    if (btnPass.Focused || btnOK.Focused)
                    {
                        button[0, 4].Focus();
                        return true;
                    }

                    if (btnBack.Focused || btnClear.Focused)
                    {
                        button[0, 0].Focus();
                        return true;
                    }

                    if (btnDelete.Focused)
                    {
                        button[0, 2].Focus();
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

                    if (btnBack.Focused)
                    {
                        btnPass.Focus();
                        return true;
                    }

                    if (btnClear.Focused)
                    {
                        btnDelete.Focus();
                        return true;
                    }

                    if (btnDelete.Focused)
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

                    if (btnPass.Focused)
                    {
                        btnBack.Focus();
                        return true;
                    }

                    if (btnOK.Focused)
                    {
                        btnDelete.Focus();
                        return true;
                    }

                    if (btnDelete.Focused)
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

                        // Vị trí kí tự ở dòng được chọn
                        row[index] = i;

                        // Vị trí kí tự ở cột được chọn
                        column[index] = j;

                        // Cộng thêm điểm
                        AddPoint();

                        // Căn giữa vị trí của lblBluePoint / lblRedPoint
                        Center();
                        return;
                    }
        }

        private void AddPoint()
        {
            if (storage.RedTurn == false)
            {
                if (btn.BackColor == Color.LightSkyBlue)
                    blueCount++;   // Nhớ tạm 1 điểm của người chơi xanh
                else
                {
                    if (btn.BackColor == Color.Red)
                    {
                        // Trừ đi 1 điểm của người chơi đỏ
                        redCount++;

                        // Cập nhật điểm của người chơi đỏ
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount);
                    }

                    if (lblBluePoint.Text == "")
                        lblBluePoint.Text = "1";
                    else
                        // Cập nhật điểm của người chơi xanh
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount + txtWords.Text.Length);
                }
            }
            else
            {
                if (btn.BackColor == Color.Red)
                    redCount++;   // Nhớ tạm 1 điểm của người chơi đỏ
                else
                {
                    if (btn.BackColor == Color.LightSkyBlue)
                    {
                        // Trừ đi 1 điểm của người chơi xanh
                        blueCount++;

                        // Cập nhật điểm của người chơi xanh
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount);
                    }

                    if (lblRedPoint.Text == "")
                        lblRedPoint.Text = "1";
                    else
                        // Cập nhật điểm của người chơi đỏ
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount + txtWords.Text.Length);
                }
            }
        }

        private void SubtractPoint()
        {
            if (storage.RedTurn == false)
            {
                if (button[row[index], column[index]].BackColor != Color.LightSkyBlue)
                {
                    if (button[row[index], column[index]].BackColor == Color.Red)
                    {
                        // Giảm điểm bị trừ của người chơi đỏ
                        redCount--;

                        // Cập nhật điểm của người chơi đỏ
                        lblRedPoint.Text = "" + (storage.RedPoint - redCount);
                    }

                    // Cập nhật điểm của người chơi xanh
                    lblBluePoint.Text = "" + (storage.BluePoint - blueCount + txtWords.Text.Length);
                }
                else
                    // Giảm điểm bị trừ của người chơi xanh
                    blueCount--;
            }
            else
            {
                if (button[row[index], column[index]].BackColor != Color.Red)
                {
                    if (button[row[index], column[index]].BackColor == Color.LightSkyBlue)
                    {
                        // Giảm điểm của người chơi xanh
                        blueCount--;

                        // Cập nhật điểm của người chơi xanh
                        lblBluePoint.Text = "" + (storage.BluePoint - blueCount);
                    }

                    // Cập nhật điểm của người chơi đỏ
                    lblRedPoint.Text = "" + (storage.RedPoint - redCount + txtWords.Text.Length);
                }
                else
                    // Giảm điểm bị trừ của người chơi đỏ
                    redCount--;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SelectLiteral();
            txtWords.Clear();
            ShowButton();

            // Hiện tất cả các kí tự vừa được chọn
            while (index >= 0)
            {
                button[row[index], column[index]].Show();
                index--;
            }

            // Cập nhật lại điểm lúc chưa chọn từ của người chơi xanh
            lblBluePoint.Text = "" + storage.BluePoint;
            
            // Xoá điểm bị trừ / nhớ tạm của người chơi xanh
            blueCount = 0;

            // Cập nhật lại điểm lúc chưa chọn từ của người chơi đỏ
            lblRedPoint.Text = "" + storage.RedPoint;

            // Xoá điểm bị trừ / nhớ tạm của người chơi đỏ
            redCount = 0;

            Center();
        }

        private void ShowButton()
        {
            // Hiện tất cả các kí tự đã được chọn
            for (int i = 0; i < index + 1; i++)
                button[row[i], column[i]].Show();
        }

        private void ChangeTurn(Storage storage)
        {
            // Thay đổi lượt chơi
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
            // Duyệt qua tất cả các từ trong file lưu trữ
            for (int i = 0; i < pf.words.Length; i++)
                if (txtWords.Text == pf.words[i])
                {
                    // Kiểm tra từ đó đã được chơi chưa
                    foreach (string str in storage.wordsListUsed)
                        if (txtWords.Text == str)
                        {
                            MessageBox.Show(str.ToUpper() + " has already been played",
                                            "Already Used");
                            return;
                        }

                    // Thêm từ vừa được chọn vào danh sách những từ đã được chơi
                    storage.wordsListUsed.Add(pf.words[i]);
                    break;
                }
                else if (pf.words[i] == pf.words[pf.words.Length - 1])
                    return;

            SelectLiteral();
            ShowButton();

            // Đánh dấu màu những kí tự được chọn
            for (int i = 0; i <= index; i++)
            {
                if (storage.RedTurn == false)
                    button[row[i], column[i]].BackColor = Color.LightSkyBlue;
                else
                    button[row[i], column[i]].BackColor = Color.Red;
            }

            // Chuyển lượt chơi
            ChangeTurn(storage);

            // Cập nhật điểm của người chơi xanh
            storage.BluePoint = int.Parse(lblBluePoint.Text);

            // Cập nhật điểm của người chơi đỏ
            storage.RedPoint = int.Parse(lblRedPoint.Text);

            txtWords.Clear();

            // Xoá điểm bị trừ / nhớ tạm của người chơi xanh
            blueCount = 0;

            // Xoá điểm bị trừ / nhớ tạm của người chơi đỏ
            redCount = 0;

            index = -1;

            if (storage.BluePoint + storage.RedPoint == 25)
            {
                hasChanged = false;
                if (hasLoaded)
                {
                    // Xoá game đã load sau khi chơi xong
                    gameSaved.RemoveAt(storage.GameLoad);
                    File.Delete(storage.FileName + ".txt");
                }

                StreamWriter sw = null;
                for (int i = 0; i < gameSaved.Count; i++)
                {
                    if (i == 0)
                    {
                        sw = new StreamWriter("game saved.txt");
                        sw.WriteLine(gameSaved[i]);
                    }
                    else
                    {
                        sw = File.AppendText("game saved.txt");
                        sw.WriteLine(gameSaved[i]);
                    }

                    sw.Close();
                }

                Stats sts = new Stats(storage);
                sts.ShowDialog();

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
                // Xoá đi kí tự sau cùng
                txtWords.Text = txtWords.Text.Remove(txtWords.Text.Length - 1);

                // Hiện kí tự được chọn sau cùng
                button[row[index], column[index]].Show();

                // Cập nhật lại điểm của người chơi
                SubtractPoint();
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

            // Nhường lượt chơi cho đối phương
            DialogResult result = MessageBox.Show("Are you sure you want to pass your turn?",
                                                  "", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                hasChanged = true;

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

        private void mnuGameLoadGame_Click(object sender, EventArgs e)
        {
            hasChanged = false;

            // Mở game đã lưu
            LoadGame lg = new LoadGame(storage);
            lg.ShowDialog();
            gameSaved = lg.gameSaved;

            // Nếu không load game
            if (storage.FileName == "")
                return;

            LoadGame();
        }

        private void LoadGame()
        {
            StreamReader sr = new StreamReader(String.Format(storage.FileName + ".txt"));

            // Số dòng đang đọc
            int count = 1;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // Các thành phần được phân tách bở dấu |
                string[] inputs = line.Split('|');
                if (count == 1)   // Dòng 1 đọc các kí tự chữ cái
                {
                    int k = 0;
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                        {
                            button[i, j].Text = inputs[k];
                            k++;
                        }
                }
                else if (count == 2)   // Dòng 2 đọc vị trí các kí tự được đánh dấu màu xanh
                {
                    // Nếu chỉ có 1 thành phần (blue) tức không có vị trí được đánh dấu màu xanh
                    if (inputs.Length == 1)
                    {
                        count++;
                        continue;
                    }

                    // Mảng chứa các vị trí ở dòng được đánh dấu màu xanh
                    int[] r = new int[inputs.Length - 1];

                    // Mảng chứa các vị trí ở cột được đánh dấu màu xanh
                    int[] c = new int[inputs.Length - 1];

                    for (int i = 0; i < inputs.Length - 1; i++)
                    {
                        string[] t = inputs[i].Split(',');
                        r[i] = int.Parse(t[0]);
                        c[i] = int.Parse(t[1]);
                        button[r[i], c[i]].BackColor = Color.LightSkyBlue;
                    }
                }
                else if (count == 3)   // Dòng 3 đọc vị trí các kí tự được đánh dấu màu đỏ
                {
                    // Nếu chỉ có 1 thành phần (red) tức không có vị trí được đánh dấu màu đỏ
                    if (inputs.Length == 1)
                    {
                        count++;
                        continue;
                    }

                    // Mảng chứa các vị trí ở dòng được đánh dấu màu đỏ
                    int[] r = new int[inputs.Length - 1];

                    // Mảng chứa các vị trí ở cột được đánh dấu màu đỏ
                    int[] c = new int[inputs.Length - 1];

                    for (int i = 0; i < inputs.Length - 1; i++)
                    {
                        string[] t = inputs[i].Split(',');
                        r[i] = int.Parse(t[0]);
                        c[i] = int.Parse(t[1]);
                        button[r[i], c[i]].BackColor = Color.Red;
                    }
                }
                else if (count == 4)   // Dòng 4 đọc điểm của 2 người chơi
                {
                    lblBluePoint.Text = inputs[0];
                    storage.BluePoint = int.Parse(lblBluePoint.Text);
                    lblRedPoint.Text = inputs[1];
                    storage.RedPoint = int.Parse(lblRedPoint.Text);
                }
                else if (count == 5)   // Dòng 5 đọc lượt chơi sau cùng
                {
                    if (line == "True")
                    {
                        pbxRedIndex.Show();
                        pbxBlueIndex.Hide();
                    }
                    else
                    {
                        pbxBlueIndex.Show();
                        pbxRedIndex.Hide();
                    }
                }
                else   // Dòng 6 đọc những từ đã được chơi
                {
                    for (int i = 0; i < inputs.Length - 1; i++)
                        storage.wordsListUsed.Add(inputs[i]);
                    break;
                }

                count++;
            }
        }

        private void mnuGameSaveGame_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (gameOver)
                return;

            // Lưu game
            if (txtWords.Text == "")
            {
                hasChanged = false;

                // Định tên file theo kiểu ngày tháng năm giờ
                storage.FileName = DateTime.Now.ToString("dd-MM-yyyy   HH mm ss");
                StreamWriter sw = new StreamWriter(String.Format(storage.FileName + ".txt"));
                
                // Dòng 1 ghi các kí tự
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        sw.Write(button[i, j].Text + "|");
                sw.WriteLine();

                // Dòng 2 ghi các vị trí được đánh dấu màu xanh
                int blue = 0;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (button[i, j].BackColor == Color.LightSkyBlue)
                        {
                            blue++;
                            sw.Write(i + "," + j + "|");
                        }

                        if (i == 4 && j == 4 && blue == 0)
                        {
                            blue--;
                            sw.Write("blue");
                        }
                    }
                if (blue > 0 || blue == -1)
                    sw.WriteLine();

                // Dòng 3 ghi các vị trí được đánh dấu màu đỏ
                int red = 0;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (button[i, j].BackColor == Color.Red)
                        {
                            red++;
                            sw.Write(i + "," + j + "|");
                        }

                        if (i == 4 && j == 4 && red == 0)
                            sw.Write("red");
                    }
                if (red == 0)
                    sw.WriteLine();

                // Dòng 4 ghi điểm của người chơi xanh và đỏ
                sw.WriteLine(storage.BluePoint + "|" + storage.RedPoint);

                // Dòng 5 ghi lượt chơi sau cùng
                sw.WriteLine(storage.RedTurn);

                // Dòng 6 ghi các từ đã được chơi
                foreach (string words in storage.wordsListUsed)
                    sw.Write(words + "|");
                sw.WriteLine();
                sw.Close();

                // Thêm tên file game đã lưu
                gameSaved.Add(storage.FileName);
                for (int i = 0; i < gameSaved.Count; i++)
                {
                    if (i == 0)
                    {
                        sw = new StreamWriter("game saved.txt");
                        sw.WriteLine(gameSaved[i]);
                    }
                    else
                    {
                        sw = File.AppendText("game saved.txt");
                        sw.WriteLine(gameSaved[i]);
                    }

                    sw.Close();
                }
                storage.GameLoad = gameSaved.Count - 1;
            }
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
            Stats sts = new Stats();
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