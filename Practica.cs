using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_9
{
    internal class Program
    {
        private int[] vector;

        // Cargar elementos en el vector
        public void Cargar()
        {
            Console.WriteLine("Busqueda Binaria");
            Console.WriteLine("Ingrese 10 Elementos");
            vector = new int[10];
            for (int f = 0; f < vector.Length; f++)
            {
                Console.WriteLine($"Ingrese el elemento {f + 1} : ");
                vector[f] = int.Parse(Console.ReadLine());
            }
        }

        // Ordenar el vector usando el método de burbuja
        public void OrdenarBurbuja()
        {
            int n = vector.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (vector[j] > vector[j + 1]) // Corregir la condición
                    {
                        // Intercambiar vector[j] y vector[j + 1]
                        int temp = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = temp;
                    }
                }
            }
        }

        // Búsqueda binaria en el vector ordenado
        public void Busqueda(int num)
        {
            int l = 0, h = vector.Length - 1;
            int m = 0;
            bool found = false;
            while (l <= h && found == false)
            {
                m = (l + h) / 2;
                if (vector[m] == num)
                    found = true;
                else if (vector[m] > num)
                    h = m - 1;
                else
                    l = m + 1;
            }
            if (found == false)
            {
                Console.WriteLine($"\nEl elemento {num} no está en el arreglo");
            }
            else
            {
                Console.WriteLine($"\nEl elemento {num} está en la posición: {m + 1}");
            }
        }

        // Nuevo método de búsqueda binaria para recibir un arreglo ordenado y un valor a buscar
        public int BusquedaBinaria(int[] arreglo, int valor)
        {
            int l = 0, h = arreglo.Length - 1;
            while (l <= h)
            {
                int m = (l + h) / 2;
                if (arreglo[m] == valor)
                    return m;
                else if (arreglo[m] > valor)
                    h = m - 1;
                else
                    l = m + 1;
            }
            return -1; // No encontrado
        }

        // Contar cuántas veces aparece un número en el arreglo
        public int ContarOcurrencias(int[] arreglo, int valor)
        {
            int count = 0;
            foreach (int num in arreglo)
            {
                if (num == valor)
                    count++;
            }
            return count;
        }

        // Imprimir los elementos del vector
        public void Imprimir()
        {
            for (int f = 0; f < vector.Length; f++)
            {
                Console.WriteLine(vector[f] + "  ");
            }
        }

        static void Main(string[] args)
        {
            Program pv = new Program();
            pv.Cargar();
            pv.OrdenarBurbuja();
            pv.Imprimir();

            Console.WriteLine("\n\nIngrese elemento a buscar: ");
            int num = int.Parse(Console.ReadLine());
            pv.Busqueda(num);

            Console.WriteLine("\n\nIngrese elemento a buscar con BusquedaBinaria: ");
            num = int.Parse(Console.ReadLine());
            int posicion = pv.BusquedaBinaria(pv.vector, num);
            if (posicion != -1)
                Console.WriteLine($"\nEl elemento {num} está en la posición: {posicion + 1}");
            else
                Console.WriteLine($"\nEl elemento {num} no está en el arreglo");

            Console.WriteLine("\n\nIngrese elemento para contar ocurrencias: ");
            num = int.Parse(Console.ReadLine());
            int ocurrencias = pv.ContarOcurrencias(pv.vector, num);
            Console.WriteLine($"\nEl elemento {num} aparece {ocurrencias} veces en el arreglo");

            Console.ReadLine();
        }
    }
}
