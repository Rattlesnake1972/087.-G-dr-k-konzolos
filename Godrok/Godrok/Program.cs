using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrok
{
    internal class Program
    {
        static int[] melysegek = new int[2000];
        static int darab = 0;
        static int felhasznalo;

        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
        }

        static void Feladat1()
        {
            Console.WriteLine("1. feladat: ");

            StreamReader reader = new StreamReader("melyseg.txt");

            string line = reader.ReadLine();

            while (line != null)
            {
                melysegek[darab] = Int32.Parse(line);
                darab++;

                line = reader.ReadLine();   
            }

            

            reader.Close();

            Console.WriteLine($"A fájl adatainak száma: {darab}");
            Console.WriteLine();

            //Console.ReadLine();


        }

        static void Feladat2()
        {
            Console.WriteLine("2. feladat: ");
            Console.Write("Adjon meg egy távolságértéket! ");

            felhasznalo = Int32.Parse( Console.ReadLine() );
            felhasznalo--;

            Console.WriteLine($"Ezen a helyen a felszín { melysegek[felhasznalo] } méter mélyen van.");

            Console.WriteLine();

            //Console.ReadLine();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat: ");

            int nullak = 0;

            for (int i = 0; i < darab; i++)
            {
                if (melysegek[i] == 0)
                {
                    nullak++;
                }
            }

            double erintetlen = (double)nullak / (double)darab *100;
            erintetlen = Math.Round(erintetlen, 2);

            //Console.WriteLine(erintetlen);

            Console.WriteLine($"Az érintetlen terület aránya {erintetlen} %.");

            //Console.WriteLine(nullak);

            Console.WriteLine();

            //Console.ReadLine(); 
        }

        static void Feladat4()
        {
            StreamWriter writer = new StreamWriter("godrok.txt");

            for (int i = 1; i < darab; i++)
            {
                if(melysegek[i] != 0)
                {
                    writer.Write( melysegek[i] +" ");
                }

                else
                {
                    if(melysegek[i -1] != 0)
                    {
                        writer.WriteLine();
                    }
                }
                
            }

            writer.Close();
            //Console.ReadLine();
        }

        static void Feladat5()
        {
            Console.WriteLine("5. feladat: ");

            int godrok = 0;

            for(int i = 1; i < darab; i++)
            {
                if(melysegek[i] != 0 && melysegek[i -1]==0)
                {
                    godrok++;
                }
            }

            Console.WriteLine($"A gödrök száma: {godrok}");
            Console.WriteLine();
            //Console.ReadLine();
        }

        static void Feladat6()
        {
            Console.WriteLine("6. feladat: ");

            if(melysegek[felhasznalo] != 0)
            {
                Feladat6a();
                Feladat6b();
                Feladat6c();
                Feladat6d();
                Feladat6e();
            }

            else
            {
                Console.WriteLine("Az adott helyen nincs gödör.");
            }

            Console.WriteLine();
        }

        static int kezdete;
        static int vege;
        static int terfogat;

        static void Feladat6a()
        {
            Console.WriteLine("a)");

            kezdete = felhasznalo;
            vege = felhasznalo;

            while(melysegek [kezdete -1] != 0)
            {
                kezdete--;
            }
            while(melysegek[vege +1] != 0)
            { 
                vege++;
            }

            Console.WriteLine($"A gödör kezdete {kezdete +1} méter, a gödör vége {vege +1} méter.");
            //Console.ReadLine();
        }

        static void Feladat6b()
        {
            Console.WriteLine("b)");

            int x = kezdete;
            int y = vege;   

            while (melysegek [x] <= melysegek[x +1])
            {
                x++;
            }
            while (y > x && melysegek [y] <= melysegek[y -1])
            {
                y--;
            }

            if (x == y)
            {
                Console.WriteLine("Folyamatosan mélyül.");
            }
            else
            {
                Console.WriteLine("Nem mélyül folyamatosan.");
            }
            Console.WriteLine();
            //Console.ReadLine();
        }

        static void Feladat6c()
        {
            Console.WriteLine("c)");

            int max = 0;

            for (int i = kezdete; i <= vege; i++)
            {
                if (melysegek[i] > max)
                {
                    max = melysegek[i];
                }
            }

            Console.WriteLine($"A legnagyobb mélysége {max} méter.");

            //Console.ReadLine();
        }

        static void Feladat6d()
        {
            Console.WriteLine("d)");

            terfogat = 0;

            for (int i = kezdete; i <= vege; i++)
            {
                terfogat += melysegek[i];
            }

            terfogat *= 10;


            Console.WriteLine($"A térfogata {terfogat} m^3.");

            //Console.ReadLine();
        }

        static void Feladat6e()
        {
            Console.WriteLine("e)");

            int viz = terfogat - ((vege - kezdete + 1) * 10);

            Console.WriteLine($"A vízmennyiség {viz} m^3.");

            Console.ReadLine();
        }

    }

}
