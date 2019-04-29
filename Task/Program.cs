using Polynom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practik1_ex2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial A = new Polynomial(new double[] { 1, 3, 3, -5 });
            Polynomial B = new Polynomial(new double[] { 3, 1, 1, 5 });

            Polynomial C = A + B;
            Polynomial D = A - B;
            Polynomial E = A * B;

            Console.Write("A=");
            Console.WriteLine(A);
            Console.Write("B=");
            Console.WriteLine(B);
            Console.Write("A+B=");
            Console.WriteLine(C);
            Console.Write("A-B=");
            Console.WriteLine(D);
            Console.Write("A*B=");
            Console.WriteLine(E);

            Console.ReadLine();
            
        }
    }
}
