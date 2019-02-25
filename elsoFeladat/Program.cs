using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace elsoFeladat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a fájl elérési utját: ");
            string utvonal = Console.ReadLine();


            do
            {

                

                while (!File.Exists(utvonal))
                {
                    Console.Clear();
                    Console.WriteLine("A cím hibás. Adja meg újra az elérési útvonalat: ");
                    utvonal = Console.ReadLine();
                }


                Beolvas(utvonal);



                if (File.Exists(utvonal))
                {
                    long meret = new System.IO.FileInfo(utvonal).Length;
                    string filename = System.IO.Path.GetFileNameWithoutExtension(utvonal);
                    string kiterjeszt = System.IO.Path.GetExtension(utvonal);

                    char[] MSH = {'b', 'B', 'c', 'C', 'd', 'D', 'f', 'F', 'g', 'G', 'h', 'H', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'p', 'P', 'q', 'Q',
                    'r', 'R','s', 'S','t', 'T','x', 'X','y', 'Y','z', 'Z','v','V','w','W'};

                    string msh = "";

                    for (int i = 0; i < filename.Length; i++)
                    {
                        for (int f = 0; f < MSH.Length; f++)
                        {
                            if (MSH[f] == filename[i])
                            {
                                msh += filename[i];
                            }
                        }
                    }


                    //Console.WriteLine(filename + " " + kiterjeszt + " " + meret);
                    Console.WriteLine();
                    Console.WriteLine($"A File neve: {filename} ");
                    Console.WriteLine($"A File nevében lévő mássalhangzók: {msh}");
                    Console.WriteLine($"A File kiterjesztése:{kiterjeszt} ");
                    Console.WriteLine($"A File merete: {meret} bite");

                }

                

            } while (!File.Exists(utvonal));

            Console.ReadKey();
        }

        private static void Beolvas(string dir)
        {
            List<string> dirki = new List<string>();
            List<string> fileki = new List<string>();

            

            if (Directory.Exists(dir))
            {

                foreach (string subdir in Directory.GetDirectories(dir))
                {
                   
                    Beolvas(subdir);
                    dirki.Add(subdir);
                }

                foreach (string file in Directory.GetFiles(dir))
                {

                    fileki.Add(file);
                }

                File.WriteAllLines("dirki.txt", dirki);
                File.WriteAllLines("fileki.txt", fileki);
                

                for (int i = 0; i < dirki.Count; i++)
                {
                    Console.WriteLine(dirki[i]);
                }

                for (int f = 0; f < fileki.Count; f++)
                {
                    Console.WriteLine(fileki[f]);
                }

                
            }
        }
    }
}
