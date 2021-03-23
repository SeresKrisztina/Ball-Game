using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ball_game
{
    class persistence
    {
        public List<int> pontok = new List<int>();
        public void Export(int score)
        {
            System.IO.StreamWriter write = new System.IO.StreamWriter("pont.txt");
            write.Write(score+"\n");
            write.Close();
        }
        public void Export()
        {
            System.IO.StreamReader read = new System.IO.StreamReader("pont.txt");
            while(!read.EndOfStream)
            {

                string line = read.ReadLine();
                string[] temp = line.Split('\n');
                for(int i=0;i<temp.Count();++i)
                {
                    pontok.Add(i);
                }
                read.Close();
            }
        }
    }
    
}
