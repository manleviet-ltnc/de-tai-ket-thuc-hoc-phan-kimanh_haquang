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
        List<int> blueScored = new List<int>();
        Label[] blueTop = new Label[10];
        List<int> redScored = new List<int>();
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

        private void LoadTop(ref Label[] blueTop, ref Label[] redTop)
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
        }

        private void LoadScored(ref Label[] blueTop, ref Label[] redTop)
        {
            StreamReader sr = null;

            sr = new StreamReader("blue scored.txt");
            string blueInput;

            int i = 0;
            while ((blueInput = sr.ReadLine()) != null)
            {
                blueTop[i].Text = blueInput;
                blueScored[i] = int.Parse(blueTop[i].Text);
                i++;
            }
            
            sr.Close();

            sr = new StreamReader("red scored.txt");
            string redInput;

            i = 0;
            while((redInput = sr.ReadLine()) != null)
            {
                redTop[i].Text = redInput;
                redScored[i] = int.Parse(redTop[i].Text);
                i++;
            }

            sr.Close();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                blueScored.Add(0);
                redScored.Add(0);
            }

            LoadTop(ref blueTop, ref redTop);
            LoadScored(ref blueTop, ref redTop);

            if (storage != null)
            {
                StreamWriter sw = null;
                if (storage.BluePoint > storage.RedPoint)
                {
                    blueScored.Add(storage.BluePoint);
                    blueScored.Sort();
                    blueScored.Reverse();
                    blueScored.RemoveAt(10);
                    if (blueScored.Count < 10)
                    {
                        for (int i = 0; i < 10; i++)
                            if (blueScored[i] == 0)
                            {
                                if (i == 0)
                                    sw = new StreamWriter("blue scored.txt");
                                else
                                    sw = File.AppendText("blue scored.txt");

                                blueTop[i].Text = blueScored[i] + "";
                                sw.WriteLine(blueTop[i].Text);
                                sw.Close();
                                break;
                            }
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == 0)
                                sw = new StreamWriter("blue scored.txt");
                            else
                                sw = File.AppendText("blue scored.txt");

                            blueTop[i].Text = blueScored[i] + "";
                            sw.WriteLine(blueTop[i].Text);
                            sw.Close();
                        }
                    }
                }
                else
                {
                    redScored.Add(storage.RedPoint);
                    redScored.Sort();
                    redScored.Reverse();
                    redScored.RemoveAt(10);
                    if (redScored.Count < 10)
                    {
                        for (int i = 0; i < 10; i++)
                            if (redScored[i] == 0)
                            {
                                if (i == 0)
                                    sw = new StreamWriter("red scored.txt");
                                else
                                    sw = File.AppendText("red scored.txt");

                                redTop[i].Text = redScored[i] + "";
                                sw.WriteLine(redTop[i].Text);
                                sw.Close();
                                break;
                            }
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (i == 0)
                                sw = new StreamWriter("red scored.txt");
                            else
                                sw = File.AppendText("red scored.txt");

                            redTop[i].Text = redScored[i] + "";
                            sw.WriteLine(redTop[i].Text);
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
