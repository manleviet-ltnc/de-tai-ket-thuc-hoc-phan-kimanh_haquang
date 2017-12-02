using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Letterpress
{
    class ProcessFile
    {
        public List<char[]> list { get; set; }
        public string[] words { get; set; }
        public string[] wordsList { get; set; }

        public void ReadData()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("words.txt");
                string inputs = sr.ReadLine();
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
                literal = words[i].ToCharArray();
                list.Add(literal);
            }
        }

        public string[] RandomLiteral()
        {
            wordsList = new string[25];

            Random rnd = new Random();
            int i = 0;
            while (i < 25)
            {
                int count = rnd.Next(0, list.Count - 1);
                foreach (char c in list[count])
                {
                    int j = 0;
                    while (j < 1)
                    {
                        wordsList[i] = "" + c;
                        i++;
                        j++;
                    }

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