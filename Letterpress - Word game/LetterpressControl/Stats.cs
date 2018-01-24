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
using LetterpressManager;

namespace LetterpressControl
{
    public partial class Stats : Form
    {
        Storage storage;
        List<string> blueScored = new List<string>();
        Label[] blueTop = new Label[10];
        List<string> redScored = new List<string>();
        Label[] redTop = new Label[10];

        public Stats()
        {
            InitializeComponent();
        }

        public Stats(Storage _storage)
        {
            InitializeComponent();
            storage = _storage;
        }

        private void LoadTop()
        {
            blueTop[0] = lblBlueTop0;
            blueTop[1] = lblBlueTop1;
            blueTop[2] = lblBlueTop2;
            blueTop[3] = lblBlueTop3;
            blueTop[4] = lblBlueTop4;
            blueTop[5] = lblBlueTop5;
            blueTop[6] = lblBlueTop6;
            blueTop[7] = lblBlueTop7;
            blueTop[8] = lblBlueTop8;
            blueTop[9] = lblBlueTop9;

            redTop[0] = lblRedTop0;
            redTop[1] = lblRedTop1;
            redTop[2] = lblRedTop2;
            redTop[3] = lblRedTop3;
            redTop[4] = lblRedTop4;
            redTop[5] = lblRedTop5;
            redTop[6] = lblRedTop6;
            redTop[7] = lblRedTop7;
            redTop[8] = lblRedTop8;
            redTop[9] = lblRedTop9;

            LoadScored();
        }

        private void LoadScored()
        {
            // Đọc vào các kết quả của người chơi xanh
            StreamReader sr = new StreamReader("blue scored.txt");
            string blueInput;
            int i = 0;
            while ((blueInput = sr.ReadLine()) != null)
            {
                blueTop[i].Text = blueInput;
                i++;
            }
            sr.Close();

            // Đọc vào các kết quả của người chơi đỏ
            sr = new StreamReader("red scored.txt");
            string redInput;
            i = 0;
            while((redInput = sr.ReadLine()) != null)
            {
                redTop[i].Text = redInput;
                i++;
            }
            sr.Close();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            LoadTop();

            // Nếu có kết quả mới
            if (storage != null)
            {
                blueScored.AddRange(new List<string>
                {
                    lblBlueTop0.Text, lblBlueTop1.Text,
                    lblBlueTop2.Text, lblBlueTop3.Text,
                    lblBlueTop4.Text, lblBlueTop5.Text,
                    lblBlueTop6.Text, lblBlueTop7.Text,
                    lblBlueTop8.Text, lblBlueTop9.Text
                });

                redScored.AddRange(new List<string>
                {
                    lblRedTop0.Text, lblRedTop1.Text,
                    lblRedTop2.Text, lblRedTop3.Text,
                    lblRedTop4.Text, lblRedTop5.Text,
                    lblRedTop6.Text, lblRedTop7.Text,
                    lblRedTop8.Text, lblRedTop9.Text
                });

                StreamWriter sw = null;
                if (storage.BluePoint > storage.RedPoint)
                {
                    // Thêm kết quả mới vào blueScored
                    blueScored.Add(storage.BluePoint + "");

                    // Sắp xếp các giá trị phần tử của blueScored theo thứ tự tăng dần
                    blueScored.Sort();

                    // Đảo ngược lại vị trí các giá trị phần tử của blueScored
                    blueScored.Reverse();

                    if (blueScored.Count < 10)
                    {
                        // Ghi tiếp vào file kết quả mới
                        sw = File.AppendText("blue scored.txt");
                        sw.WriteLine(blueScored[blueScored.Count - 1]);
                        sw.Close();
                    }
                    else
                    {
                        // Bỏ đi kết quả thấp nhất
                        blueScored.RemoveAt(10);

                        // Ghi lại các kết quả vào file blue scored.txt
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == 0)
                                sw = new StreamWriter("blue scored.txt");
                            else
                                sw = File.AppendText("blue scored.txt");

                            sw.WriteLine(blueScored[i]);

                            // Gán lại các giá trị đã sắp xếp cho redTop để hiện ra trên form
                            blueTop[i].Text = blueScored[i];
                            sw.Close();
                        }
                    }
                }
                else
                {
                    // Thêm kết quả mới vào redScored
                    redScored.Add(storage.RedPoint + "");

                    // Sắp xếp các giá trị phần tử của redScored theo thứ tự tăng dần
                    redScored.Sort();

                    // Đảo ngược lại vị trí các giá trị phần tử của redScored
                    redScored.Reverse();

                    if (redScored.Count < 10)
                    {
                        // Ghi tiếp vào file kết quả mới
                        sw = File.AppendText("red scored.txt");
                        sw.WriteLine(redScored[redScored.Count - 1]);
                        sw.Close();
                    }
                    else
                    {
                        // Bỏ đi kết quả thấp nhất
                        redScored.RemoveAt(10);

                        // Ghi lại các kết quả vào file red scored.txt
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == 0)
                                sw = new StreamWriter("red scored.txt");
                            else
                                sw = File.AppendText("red scored.txt");

                            sw.WriteLine(redScored[i]);

                            // Gán lại các giá trị đã sắp xếp cho redTop để hiện ra trên form
                            redTop[i].Text = redScored[i];
                            sw.Close();
                        }
                    }
                }
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}