using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PROGRAMABIBLIOTECA
{
    class Menu
    {
        public void mostrarMenu()
        {
            string opcion, librotesis;
            Textos textos;
            textos = new Textos();

            do
            {
                Console.Clear();

                Console.WriteLine("\n MENÚ DE OPCIONES ");
                Console.WriteLine("\n (A) Ingresar un libro o tesis");
                Console.WriteLine("\n (B) Buscar un libro o tesis, por autor");
                Console.WriteLine("\n (C) Modificar los datos de un libro o tesis");
                Console.WriteLine("\n (D) Desincorporar un libro o ejemplar");
                Console.WriteLine("\n (E) Procesar un préstamo");
                Console.WriteLine("\n (F) Procesar un reintegro");
                Console.WriteLine("\n (G) Listar los libros");
                Console.WriteLine("\n (H) Listar los préstamos");
                Console.WriteLine("\n (I) Listar tesis de grado");
                Console.WriteLine("\n (J) Listar tesis de grado, por asesor");
                Console.WriteLine("\n (K) Salir");
                Console.Write("\n Opción: ");
                opcion = Console.ReadLine().ToUpper();

                switch (opcion)
                {
                    case "A":
                        Console.Clear();
                        Console.WriteLine("Presione 1 para ingresar un libro, 2 para ingresar una tesis u otro para regresar\n");
                        librotesis = Console.ReadLine();

                        switch (librotesis)
                        {
                            case "1": textos.ingresarLibro(); break;
                            case "2": textos.ingresarTesis(); break;
                        }
                        break;

                    case "B":
                        Console.Clear();
                        Console.WriteLine("Presione 1 para buscar un libro, 2 para ingresar una tesis u otro para regresar\n");
                        librotesis = Console.ReadLine();

                        switch (librotesis)
                        {
                            case "1": textos.buscarLibro(); break;
                            case "2": textos.buscarTesis(); break;
                        }
                        break;

                    case "C":
                        Console.Clear();
                        Console.WriteLine("Presione 1 para modificar un libro, 2 para ingresar una tesis u otro para regresar\n");
                        librotesis = Console.ReadLine();

                        switch (librotesis)
                        {
                            case "1": textos.modificarLibro(); break;
                            case "2": textos.modificarTesis(); break;
                        }
                        break;

                    case "D":
                        Console.Clear();
                        Console.WriteLine("Presione 1 para eliminar un libro, 2 para eliminar solo un ejemplar u otro para regresar\n");
                        librotesis = Console.ReadLine();

                        switch (librotesis)
                        {
                            case "1": textos.eliminarLibro(); break;
                            case "2": textos.eliminarEjemplar(); break;
                        }
                        break;

                    case "E":
                        Console.Clear();
                        Console.WriteLine("Denos su información para procesar el préstamo...\n");
                        textos.procesarPréstamo();
                        break;

                    case "F":
                        Console.Clear();
                        Console.WriteLine("Denos su información para procesar el reintegro...\n");
                        textos.procesarReintegro();
                        break;

                    case "G":
                        Console.Clear();
                        textos.listadoLibros();
                        break;

                    case "H":
                        Console.Clear();
                        textos.listadoPrestamos();
                        break;

                    case "I":
                        Console.Clear();
                        textos.listadoTesis();
                        break;

                    case "J":
                        Console.Clear();
                        textos.listadoTesisAsesor();
                        break;

                    case "K":
                        Console.WriteLine("Salió del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                Console.ReadKey();
            } while (opcion != "K");
        }
    }
}