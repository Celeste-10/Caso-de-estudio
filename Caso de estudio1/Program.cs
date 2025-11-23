using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Anio { get; set; }
    public string Descripcion { get; set; }
}
namespace Caso_de_estudio1
{

    public class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>
        {
            new Libro {Titulo="Programación en C#", Autor="Juan Pérez", Anio=2020, Descripcion="Guía para aprender C# desde cero"},
            new Libro {Titulo="Estructuras de Datos", Autor="María López", Anio=2018, Descripcion="Explicación de listas, pilas y colas"},
            new Libro {Titulo="POO Avanzada", Autor="Carlos Ruiz", Anio=2022, Descripcion="Conceptos avanzados de programación orientada a objetos"},
            new Libro {Titulo="Algoritmos", Autor="Ana Torres", Anio=2015, Descripcion="Búsqueda y ordenamiento"}
        };

            string[] autores = { "Ana Torres", "Carlos Ruiz", "Juan Pérez", "María López" };

            int opcion;
            do
            {
                Console.WriteLine("\n==== Sistema de Búsqueda ====");
                Console.WriteLine("1. Búsqueda lineal por título");
                Console.WriteLine("2. Búsqueda binaria por autor");
                Console.WriteLine("3. Libro más reciente y más antiguo");
                Console.WriteLine("4. Buscar coincidencias en descripción");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        BusquedaLineal(libros);
                        break;

                    case 2:
                        BusquedaBinaria(autores);
                        break;

                    case 3:
                        BuscarLibrosExtremos(libros);
                        break;

                    case 4:
                        BuscarCoincidencias(libros);
                        break;
                }

            } while (opcion != 5);
        }

        static void BusquedaLineal(List<Libro> libros)
        {
            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            foreach (var libro in libros)
            {
                if (libro.Titulo.ToLower().Contains(titulo.ToLower()))
                {
                    Console.WriteLine($"Encontrado: {libro.Titulo} ({libro.Autor}, {libro.Anio})");
                    return;
                }
            }

            Console.WriteLine("No se encontró el libro.");
        }

        static void BusquedaBinaria(string[] autores)
        {
            Console.Write("Ingrese el autor a buscar: ");
            string autor = Console.ReadLine();

            int inicio = 0, fin = autores.Length - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;

                if (autores[medio].Equals(autor, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Autor encontrado: {autores[medio]}");
                    return;
                }

                if (string.Compare(autor, autores[medio], true) < 0)
                    fin = medio - 1;
                else
                    inicio = medio + 1;
            }

            Console.WriteLine("No se encontró el autor.");
        }

        static void BuscarLibrosExtremos(List<Libro> libros)
        {
            Libro reciente = libros[0];
            Libro antiguo = libros[0];

            foreach (var libro in libros)
            {
                if (libro.Anio > reciente.Anio)
                    reciente = libro;

                if (libro.Anio < antiguo.Anio)
                    antiguo = libro;
            }

            Console.WriteLine($"Libro más reciente: {reciente.Titulo} ({reciente.Anio})");
            Console.WriteLine($"Libro más antiguo: {antiguo.Titulo} ({antiguo.Anio})");
        }
        static void BuscarCoincidencias(List<Libro> libros)
        {
            Console.Write("Ingrese palabra clave: ");
            string palabra = Console.ReadLine();

            bool encontrado = false; 

            foreach (var libro in libros)
            {
                if (libro.Descripcion.ToLower().Contains(palabra.ToLower()))
                {
                    Console.WriteLine($"Coincidencia en: {libro.Titulo} → {libro.Descripcion}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron coincidencias.");
            }
        }

    
    }
}
