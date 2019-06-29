using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisson
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = 2.718281828459045235360;
            double x = 0;
            double demanda;
            double maximo = 0;
            Random aleatorio = new Random();
            double ale;

            List<double> Fxi = new List<double>();
            List<double> Fxz = new List<double>();
            List<double> NumRectangulares = new List<double>();

            /*NumRectangulares.Add(0.80359); NumRectangulares.Add(0.95431);
            NumRectangulares.Add(0.99763); NumRectangulares.Add(0.99958);
            NumRectangulares.Add(0.99997);*/

            Console.Write("Introduce la demanda de la semana 5: ");
            double alfa = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < alfa; i++)
            {
                ale = aleatorio.Next(10001, 99999);
                Convert.ToDouble(ale);
                NumRectangulares.Add(ale / 100000);
                Console.WriteLine(NumRectangulares[i]);

            }
            Console.WriteLine("");

            for (int i = 0; i <= 10000; i++)
            {
                int Resultado = Factorial(i);
                Convert.ToDouble(Resultado);
                if (Resultado == 0)
                {
                    Resultado = 1;
                }
                demanda = (((Math.Pow(e, -(alfa))) * (Math.Pow(alfa, i))) / (Resultado));
                Fxi.Add(demanda);

            }
            Fxz.Add(Fxi[0]);
            int uno = 1;
            Console.WriteLine("x  " + "     f(xi) " + "           f(xi) ");
            for (int i = 0; i <= 10000; i++)
            {
                if (uno < 100)
                {
                    x = Fxz[i] + Fxi[uno];
                    maximo = x;
                    Fxz.Add(x);
                    if (maximo < 0.99995)
                    {
                        //Console.WriteLine(i +"        "+ Fxi[i] +"         "+ Fxz[i]);
                        Console.WriteLine(i + "      " + "{0:N5}" + "          " + "{1:N5}", Fxi[i], Fxz[i]);
                    }
                    else if (maximo > 1)
                    {
                        break;
                    }

                    uno++;
                }

            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            double a = 0;
            Double valor, suma = 0, menor, mayor;

            for (int i = 0; i < Fxz.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("SI R > " + a + " y <= " + " {0:N5}" + " Entonces x=" + i, Fxz[i]);
                }
                else
                {
                    Console.WriteLine("SI R > " + "{0:N5}" + " y <= " + " {1:N5}" + " Entonces x=" + i, Fxz[i - 1], Fxz[i]);
                }
            }

            //Imprimir la semana 
            Console.WriteLine("");
            for (int i = 0; i < Fxz.Count; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < NumRectangulares.Count; j++)
                    {
                        menor = a; mayor = Fxz[i];
                        valor = NumRectangulares[j];
                        if (valor > menor && valor <= mayor)
                        {
                            suma = suma + i;
                            Console.WriteLine("Dia " + j + " = " + NumRectangulares[j] + " = " + i);
                        }
                    }
                }
                else
                {
                    for (int z = 0; z < NumRectangulares.Count; z++)
                    {
                        menor = Fxz[i - 1]; mayor = Fxz[i];
                        valor = NumRectangulares[z];
                        if (valor > menor && valor <= mayor)
                        {
                            suma = suma + i;
                            Console.WriteLine("Dia " + z + " = " + NumRectangulares[z] + " = " + i);
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Total = " + suma);

            Console.ReadKey();
        }

        public static int Factorial(int num)
        {
            int resultado = num;
            for (int i = num - 1; i > 1; i--)
            {
                resultado *= i;
            }
            return resultado;
        }
    }
}
