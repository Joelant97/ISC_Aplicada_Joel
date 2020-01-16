using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EjerciciosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code #:1

            /* int valor1, valor2;
            Console.WriteLine("Escribe el primer valor: ");
            valor1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escribe el segundo valor: ");
            valor2 = Convert.ToInt32(Console.ReadLine());

            valor1 += valor2;

            Console.WriteLine("Resultado: " + valor1);
            Console.ReadKey();

            return; */


            // Code #:2 

            /* int valor;
            List<int> valores = new List<int>();
            Console.WriteLine("Escribe los valores (0 para salir): ");

            while ((valor = Convert.ToInt32(Console.ReadLine())) != 0)

            {
                valores.Add(valor);
                Console.WriteLine("Capturado. Digite otro valor...");

            }

            Console.WriteLine("Resultados: " + valores.Sum());
            Console.ReadKey();

            return; */


            // Code #:3 

            int[,] matriz = new int[6, 6];

            Console.WriteLine("Generando una matriz 6x6:\n");

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    matriz[i, j] = (i + j) * (i + 1) + (j + 4) - (i * 3) + (i + j);

            foreach (int val in matriz)
                Console.WriteLine("{0}", val);

            Console.ReadKey();

            return; 


        }
}
}






