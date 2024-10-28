using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{ //BynarryFormaterr
    [Serializable]
    class Puntuacion
    {
        public string Jugador { get; set; }
        public int Puntos { get; set; }
    }

    internal class Program
    {
        static void AgregarPuntuacion(List<Puntuacion> puntuaciones, string jugador, int puntos)
        {
            puntuaciones.Add(new Puntuacion { Jugador = jugador, Puntos = puntos });
        }

        static void EliminarPuntuacion(List<Puntuacion> puntuaciones, string jugador)
        {
            puntuaciones.RemoveAll(p => p.Jugador == jugador);
        }

        static void MostrarPuntuaciones(List<Puntuacion> puntuaciones)
        {
            foreach (var p in puntuaciones)
            {
                Console.WriteLine($"Jugador: {p.Jugador}, Puntos: {p.Puntos}");
            }
        }

        static void GuardarPuntuaciones(List<Puntuacion> puntuaciones)
        {
            FileStream ArchivoEscritor = new FileStream("Datos.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter Escritor = new BinaryWriter(ArchivoEscritor);
            foreach (var p in puntuaciones)
            {
                Escritor.Write(p.Jugador);
                Escritor.Write(p.Puntos);
            }
            Escritor.Close();
            ArchivoEscritor.Close();
        }
        static void Main(string[] args)
        {

            FileStream ArchivoEscritor;
            FileStream ArchivoLector;
            BinaryWriter Escritor;
            BinaryReader Lector;
            List<Puntuacion> puntuaciones = new List<Puntuacion>();

            //cargar puntuaciones desde el archivo al iniciar
            if (File.Exists("Datos3.dat"))
            {
                ArchivoLector = new FileStream("Datos3.dat", FileMode.Open, FileAccess.Read);
                Lector = new BinaryReader(ArchivoLector);
                while (Lector.BaseStream.Position != Lector.BaseStream.Length)
                {
                    string jugador = Lector.ReadString();
                    int puntos = Lector.ReadInt32();
                    puntuaciones.Add(new Puntuacion { Jugador = jugador, Puntos = puntos });
                }
                Lector.Close();
                ArchivoLector.Close();
            }

            //permitir al usuario ingresar nuevas puntuaciones
            while (true)
            {
                Console.WriteLine("Ingrese el nombre del jugador (o 'salir' para terminar):");
                string jugador = Console.ReadLine();
                if (jugador.ToLower() == "salir")
                    break;

                Console.WriteLine("Ingrese la puntuación del jugador:");
                if (int.TryParse(Console.ReadLine(), out int puntos))
                {
                    AgregarPuntuacion(puntuaciones, jugador, puntos);
                }
                else
                {
                    Console.WriteLine("Puntuación inválida. Inténtalo de nuevo.");
                }
            }

            //mostrar todas las puntuaciones
            Console.WriteLine("Puntuaciones:");
            MostrarPuntuaciones(puntuaciones);

            //permitir al usuario eliminar puntuaciones
            Console.WriteLine("Ingrese el nombre del jugador a eliminar (o 'ninguno' para continuar):");
            string jugadorAEliminar = Console.ReadLine();
            if (jugadorAEliminar.ToLower() != "ninguno")
            {
                EliminarPuntuacion(puntuaciones, jugadorAEliminar);
            }

            //mostrar puntuaciones después de eliminar
            Console.WriteLine("Después de eliminar:");
            MostrarPuntuaciones(puntuaciones);

            //guardar puntuaciones en el archivo
            GuardarPuntuaciones(puntuaciones);

            //mantener la consola abierta
            Console.ReadLine();
        }
    }
}

