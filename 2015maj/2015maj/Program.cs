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
            Console.WriteLine();
            List<adas> adasok = beolvas();
            Console.WriteLine("Bolvasás kész.");

            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az első üzenet rögzítője: " + adasok[0].amator);
            Console.WriteLine("Az utolsó üzenet röögzítője: " + adasok[adasok.Count - 1].amator + Environment.NewLine);

            Console.WriteLine("3. feladat:");
            kiir(farkaskeres(adasok), adasok);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("4. feladat:");
            kiir(napossz(adasok));
            Console.WriteLine();

            Console.WriteLine("5. feladat:");
            kiir(helyreallit(adasok));
            Console.WriteLine("Kiírás kész.");

            

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
            sr.Close();
            f.Close();
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

        static int[] napossz(List<adas> adasok)
        {
            int[] ossz = new int[11];
            for (int i = 0; i < adasok.Count; i++)
            {
                ossz[adasok[i].nap - 1]++;
            }
            return ossz;
        }

        static void kiir(int[] kiirando)
        {
            for (int i = 0; i < kiirando.Length; i++)
            {
                Console.WriteLine("{0}. nap: {1} amatőr.", i + 1, kiirando[i]);
            }
        }

        static string[] helyreallit(List<adas> adasok)
        {
            string[] eredmeny = new string[11];
            List<string>[] uzenetek = new List<string>[11];
            for (int i = 0; i < 11; i++)
            {
                uzenetek[i] = new List<string>();
            }

            for (int i = 0; i < adasok.Count; i++)
            {
                uzenetek[adasok[i].nap-1].Add(adasok[i].uzenet);
            }
            bool cserelt = false;
            for (int i = 0; i < uzenetek.Length; i++)
            {
                for (int j = 0; j < 90; j++)
                {
                    for (int k = 0; k < uzenetek[i].Count; k++)
                    {
                        if (uzenetek[i][k][j] != '#' && !cserelt)
                        {
                            eredmeny[i] += uzenetek[i][k][j];
                            cserelt = true;
                        }
                    }
                    if (!cserelt)
                        eredmeny[i] += '#';
                    cserelt = false;
                }
            }
            return eredmeny;
        }

        static void kiir(string[] kiirando)
        {
            FileStream f = new FileStream(@"C:\érettségi megoldas\forrasok\adas.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            for (int i = 0; i < kiirando.Length; i++)
            {
                sw.WriteLine(kiirando[i]);
            }
            sw.Close();
            f.Close();
        }
    }
}
