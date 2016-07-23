using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kayttoOhj1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lukusumma Summa = new Lukusumma();
            Lukusumma kerto = new Lukukerto();
            Lukukerto Kerto = new Lukukerto();

            Console.WriteLine(Summa.laske(2, 4));
            Console.WriteLine(kerto.laske(2, 4));
            Console.WriteLine(Kerto.laske(2, 4));
            Console.ReadKey(); 
        }

        static int summa(int luku1, int luku2)
        {
            return luku1 + luku2;
        }
    }


    class Lukusumma
    {
        virtual public int laske(int luku1, int luku2)
        {
            return luku1 + luku2;
        }


    }


    class Lukukerto : Lukusumma
    {
        public override int laske(int luku1, int luku2)
        {
            return luku1 * luku2;
        }
    }
}
