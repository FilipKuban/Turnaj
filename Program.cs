using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnaj
{
    class Postava
    {
        public string Jmeno;
        public int UtokZBlizka = 0;
        public int Uhybani = 0;
        public int UtokZDalky = 0;
        public int Obrana = 0;
        public int Presnost = 0;
        public int Zivoty = 0;

        public Postava(string jmeno, int utokZBlizka, int uhybani, int utokZDalky, int obrana, int presnost, int zivoty)
        {
            Jmeno = jmeno;
            Zivoty = zivoty;
            UtokZBlizka = utokZBlizka;
            Uhybani = uhybani;
            UtokZDalky = utokZDalky;
            Obrana = obrana;
            Presnost = presnost;
        }

        public void VypisAtributy()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"{Jmeno}");
            Console.WriteLine($"Utok z blizka: {UtokZBlizka}");
            Console.WriteLine($"Utok z dalky: {UtokZDalky}");
            Console.WriteLine($"Uhybani: {Uhybani}");
            Console.WriteLine($"Obrana: {Obrana}");
            Console.WriteLine($"Presnost: {Presnost}");
            Console.WriteLine($"Zivoty: {Zivoty}");
            Console.WriteLine("------------------------");
        }
        public int SpocitejPrumernouObranu()
        {
            int vyledek = (Uhybani + Obrana) / 2;
            return vyledek;
        }
        public int VypocetUtoku(int typUtoku)
        {
            switch (typUtoku)
            {
                case 1: return UtokZBlizka + Presnost / 3;
                case 2: return UtokZDalky + Presnost / 2;
                default: return 0;
            }
        }
        public void ZmenaDovednosti(int cisloKPricteni)
        {
            UtokZBlizka += cisloKPricteni;
            Uhybani += cisloKPricteni;
            UtokZDalky += cisloKPricteni;
            Obrana += cisloKPricteni;
            Presnost += cisloKPricteni;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Postava[] nepratele = new Postava[4];
            Random nahodnaCisla = new Random();


            Postava postavaHrace = new Postava("",0,0,0,0,0,100) ;
            Console.WriteLine("Ahoj,\nzadej jmeno postavy: ");
            postavaHrace.Jmeno = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Vytej {postavaHrace.Jmeno}");
            Console.WriteLine("Tva postava potrebuje jeste rozdelit dovdnostni body.");
            int bodyKRozeleni = 35;
            while (bodyKRozeleni > 0)
            {
                Console.WriteLine($"Zbyva rozdelit {bodyKRozeleni} bodu");
                Console.WriteLine("Kterou dovednost chces vylepsit?");
                Console.WriteLine($"P - presnost ({postavaHrace.Presnost})");
                Console.WriteLine($"O - obrana ({postavaHrace.Obrana})");
                Console.WriteLine($"Z - utok z blizka ({postavaHrace.UtokZBlizka})");
                Console.WriteLine($"D - utok z dalky ({postavaHrace.UtokZDalky})");
                Console.WriteLine($"U - uhybani ({postavaHrace.Uhybani})");
                Console.WriteLine("Zvol P/O/Z/D/U");
                string zvolenoRozdeleni = Console.ReadLine();
                switch (zvolenoRozdeleni.ToUpper())
                {
                    case "P": postavaHrace.Presnost += 5; bodyKRozeleni -= 5; break;
                    case "O": postavaHrace.Obrana += 5; bodyKRozeleni -= 5; break;
                    case "Z": postavaHrace.UtokZBlizka += 5; bodyKRozeleni -= 5; break;
                    case "D": postavaHrace.UtokZDalky += 5; bodyKRozeleni -= 5; break;
                    case "U": postavaHrace.Uhybani += 5; bodyKRozeleni -= 5; break;
                    default: Console.WriteLine("Nepltna volba :("); break;
                }
                Console.Clear();
            }
            postavaHrace.VypisAtributy();
            Console.WriteLine($"Prumerna hodnota obrany: {postavaHrace.SpocitejPrumernouObranu()}");
            int cislo = nahodnaCisla.Next(-2, 3);
            Console.WriteLine($"Chces skusit stesti? A/N");
            string odpoved = Console.ReadLine();
            if (odpoved.ToUpper()=="A")
            {
                postavaHrace.ZmenaDovednosti(cislo);
                Console.WriteLine("Dovednostni body byly prerozdeleny");
                postavaHrace.VypisAtributy();
                Console.WriteLine("Pokracuj stiskem klavesi");
                Console.ReadKey(false);
                Console.Clear();
            }
            nepratele[0] = new Postava("Rytir",10,15,15,10,10,40);
            nepratele[1] = new Postava("Skret",12,17,19,13,12,50);
            nepratele[2] = new Postava("Mrtvak",  15, 20, 22, 15, 15,60);
            nepratele[3] = new Postava("Vlkodlak",  18, 25, 25, 18, 18,70);
            Console.WriteLine("Tvoji protivnici v turnaji: ");
            Console.WriteLine("------------------------");
            foreach (Postava item in nepratele)
            {
                Console.WriteLine($"{item.Jmeno} {item.Zivoty} zivotu");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Pokracuj stiskem klavesi");
            Console.ReadKey(false);
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine($"Turnaj zacina :)");
            for (int I = 0; I < nepratele.Length; I++)
            {
                postavaHrace.VypisAtributy();
                Console.WriteLine($"Proti");
                nepratele[I].VypisAtributy();
                while (postavaHrace.Zivoty > 0 && nepratele[I].Zivoty > 0)
                {
                    Console.WriteLine($"{postavaHrace.Jmeno} {postavaHrace.Zivoty} zivotu");
                    Console.WriteLine($"{nepratele[I].Jmeno} {nepratele[I].Zivoty} zivotu");
                    string zadanyTypUtoku;
                    do
                    {
                        Console.WriteLine($"Zvol typ utoku (D = z dalky, Z = zblizka: ");
                        zadanyTypUtoku = Console.ReadLine();
                    } while ((zadanyTypUtoku.ToUpper() != "D")&&(zadanyTypUtoku.ToUpper() != "Z"));
                    int silaUtoku = 0, obrana = 0;
                    switch (zadanyTypUtoku)
                    {
                        case "Z": silaUtoku = postavaHrace.VypocetUtoku(1);obrana = nepratele[I].Obrana; break;
                        case "D": silaUtoku = postavaHrace.VypocetUtoku(2); obrana = nepratele[I].Uhybani; break;
                    }
                    Console.Clear();
                    if (silaUtoku>obrana)
                    {
                        Console.WriteLine($"Zasach, spusobene zraneni: {silaUtoku-obrana}");
                        nepratele[I].Zivoty -= silaUtoku - obrana;
                    }
                    else
                    {
                        Console.WriteLine($"{nepratele[I].Jmeno} se ubranil");
                    }
                    if (nepratele[I].Zivoty <= 0)
                    {
                        Console.WriteLine($"{nepratele[I].Jmeno} byl porazen :)");
                        break;
                    }
                    int typUtokuNepritele = nahodnaCisla.Next(1, 3);
                    switch (typUtokuNepritele)
                    {
                        case 1: Console.WriteLine($"{nepratele[I].Jmeno} pouzil utok z blizka");obrana = postavaHrace.Obrana;silaUtoku = nepratele[I].VypocetUtoku(1); break;
                        case 2: Console.WriteLine($"{nepratele[I].Jmeno} pouzil utok z zdalky"); obrana = postavaHrace.Uhybani;silaUtoku = nepratele[I].VypocetUtoku(2); break;
                    }
                    if (silaUtoku> obrana)
                    {
                        postavaHrace.Zivoty -= silaUtoku - obrana;
                        Console.WriteLine($"{nepratele[I].Jmeno} te zasahl a spusobyl ti zraneni: {silaUtoku-obrana}\nZbiva ti: {postavaHrace.Zivoty} zivotu");
                    }
                    else
                    {
                        Console.WriteLine($"Utok nepritele odrazen :)");
                    }
                }
                if (postavaHrace.Zivoty >0)
                {
                    Console.WriteLine("Souboj vyhran");
                    Console.ReadKey(false);
                }
                else
                {
                    Console.WriteLine("Tvuj hrdina byl porazen");
                    Console.ReadKey(false);
                    break;
                }
            }
            if (postavaHrace.Zivoty > 0)
            {
                Console.WriteLine("Cely turnaj vyhran :)");
                Console.ReadKey(false);
            }
        }
    }
}
