using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LetterpressManager
{
    public class ProcessFile
    {
        public List<char[]> list { get; set; }
        public string[] words { get; set; }
        public string[] wordsList = new string[25];

        public void ReadData()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("words.txt");
                string inputs = sr.ReadLine();

                // Lưu mỗi từ đọc được vào mỗi chỉ số trong mảng words
                words = inputs.Split(' ');
                ReadLiteral(words);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public void ReadLiteral(string[] words)
        {
            list = new List<char[]>();
            char[] literal = new char[] { };
            for (int i = 0; i < words.Length; i++)
            {
                // Thêm mỗi ký tự của mỗi từ vào mỗi chỉ số trong mảng literal
                literal = words[i].ToCharArray();

                // Thêm giá trị của các chỉ số trong mảng literal vừa thêm vào 1 vùng nhớ
                list.Add(literal);
            }
        }

        public string[] RandomLiteral()
        {
            Random rnd = new Random();
            int i = 0;
            while (i < 25)
            {
                // Lấy ngẫu nhiên một ô nhớ trong list tương ứng với các ký tự trong đó
                int count = rnd.Next(0, list.Count - 1);
                foreach (char c in list[count])
                {
                    // Gán các kí tự đó vào các chỉ số trong mảng wordsList
                    wordsList[i] = "" + c;
                    i++;

                    if (i == 25)
                        break;
                }
            }

            // Xáo trộn các giá trị trong wordsList
            string[] shuffled = wordsList.OrderBy(n => Guid.NewGuid()).ToArray();
            return shuffled;
        }
    }
}