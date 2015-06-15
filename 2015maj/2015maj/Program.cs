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

            Console.WriteLine("3. feladat:");
            kiir(farkaskeres(adasok), adasok);
            Console.WriteLine();

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

        static List<int> farkaskeres(List<adas> adasok)
        {
            List<int> talalatok = new List<int>();
            for (int i = 0; i < adasok.Count; i++)
            {
                if (adasok[i].uzenet.Contains("farkas"))
                    talalatok.Add(i);
            }
            return talalatok;
        }

        static void kiir(List<int> talalatok, List<adas> adasok)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            Console.Write("Nap");

            Console.CursorLeft = x + 7;
            Console.CursorTop = y;
            Console.Write("Amatőr");

            for (int i = 0; i < talalatok.Count; i++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y + i + 1;
                Console.Write(adasok[talalatok[i]].nap);

                Console.CursorLeft = x + 7;
                Console.CursorTop = y + i + 1;
                Console.Write(adasok[talalatok[i]].amator);
            }
        }
    }
}
