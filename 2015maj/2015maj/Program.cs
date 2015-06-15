using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2015maj
{
    class Program
    {
        public const string fajlhely = @"C:\érettségi megoldas\forrasok\veetel.txt";

        public struct adas
        {
            public int amator;
            public int nap;
            public string uzenet;
        }

        static void Main(string[] args)
        {
            List<adas> adasok = beolvas();

            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az első üzenet rögzítője: " + adasok[0].amator);
            Console.WriteLine("Az utolsó üzenet röögzítője: " + adasok[adasok.Count-1].amator + Environment.NewLine);

            Console.ReadKey();
        }

        static List<adas> beolvas()
        {
            
            List<adas> adasok = new List<adas>();
            FileStream f = new FileStream(fajlhely, FileMode.Open);
            StreamReader sr = new StreamReader(f);
            string s = sr.ReadLine();
            string[] stomb;
            int i = 0;
            adas sadas = new adas();
            while (s != null)
            {
                stomb = s.Split(' ');
                sadas.nap = int.Parse(stomb[0]);
                sadas.amator = int.Parse(stomb[1]);

                s = sr.ReadLine();
                sadas.uzenet = s;
                s = sr.ReadLine();
                i++;
                adasok.Add(sadas);
            }
            return adasok;
        }
    }
}
