using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMABIBLIOTECA
{
     class Textos
    {
        // Atributos
        protected List<Libro> Libros { get; set; }
        protected List<Tesis> Tesis { get; set; }

        // Constructor de la clase
        public Textos()
        {
            Libros = new List<Libro>();
            Tesis = new List<Tesis>();
        }

        // Métodos de Get Set
        protected List<Libro> GetLibros()
        {
            return Libros;
        }
        protected void SetLibros(List<Libro> libros)
        {
            Libros = libros;
        }
        protected void SetTesis(List<Tesis> tesis)
        {
            Tesis = tesis;
        }
        protected List<Tesis> GetTesis()
        {
            return Tesis;
        }

        // Métodos de Ingreso
        public void ingresarLibro()
        {
            List<Libro> nuevaLista = GetLibros();
            string titulo, edit;
            int nAutor, ejemp, año;        
            List<string> autor = new();
            List<string> isbn = new();


            do
            {
                Console.WriteLine("Ingrese el título del libro: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            do
            {
                Console.WriteLine("Ingrese la cantidad de autores del libro: ");
                nAutor = int.Parse(Console.ReadLine());
            } while (nAutor < 1 || string.IsNullOrWhiteSpace(nAutor.ToString ()));

            for (int i = 0; i < nAutor; i++)
            {
                string nuevoAutor;
                do
                {
                    Console.WriteLine("Ingrese el autor #{0} de libro", i + 1);
                    nuevoAutor = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nuevoAutor));

                autor.Add(nuevoAutor);
            }

            do
            {
                Console.WriteLine("Ingrese la cantidad de ejemplares del libro: ");
                ejemp = int.Parse(Console.ReadLine());
            }while (ejemp < 0 || string.IsNullOrWhiteSpace(ejemp.ToString ()));

            for (int i = 0; i < ejemp; i++)
            {
                string nuevoIsbn;
                do
                {
                    Console.WriteLine("Ingrese el ISBN del ejemplar #{0} del libro", i + 1);
                    nuevoIsbn = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nuevoIsbn));
                isbn.Add(nuevoIsbn);
            }

            do
            {
                Console.WriteLine("Ingrese la editorial del libro: ");
                edit = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(edit));

            do
            {
                Console.WriteLine("Ingrese el año del libro: ");
                año = int.Parse(Console.ReadLine());
            } while (año < 1 || año > 2024 || string.IsNullOrWhiteSpace(año.ToString()));

            Libro nuevoLibro = new(titulo, autor, ejemp, isbn, edit, año);
            nuevaLista.Add(nuevoLibro);
            SetLibros(nuevaLista);

            Console.WriteLine("Proceso Exitoso!!!");
            Console.ReadKey();
        }

        public void ingresarTesis()
        {
            List<Tesis> nuevaLista = GetTesis();
            string titulo, carrera, asesor;
            int nAutor, año;
            List<string> autor = new List<string>();

            do 
            {
                Console.WriteLine("Ingrese el título de la tesis: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            do
            { Console.WriteLine("Ingrese la carrera de la tesis: ");
                carrera = Console.ReadLine();
            }while(string.IsNullOrWhiteSpace(carrera));

            do
            {
                Console.WriteLine("Ingrese el asesor de la tesis: ");
                asesor = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(asesor));

            do
            {
                Console.WriteLine("ingrese la cantidad de autores de la tesis: ");
                nAutor = int.Parse(Console.ReadLine());
            } while (nAutor < 1|| string.IsNullOrWhiteSpace(nAutor.ToString ()));

            for (int i = 0; i < nAutor; i++)
            {
                string nuevoAutor;
                do
                {
                    Console.WriteLine("Ingrese el autor #{0} de la tesis", i + 1);
                    nuevoAutor = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nuevoAutor));
                autor.Add(nuevoAutor);
            }


            do
            {
                Console.WriteLine("Ingrese el año de la tesis: ");
                año = int.Parse(Console.ReadLine());
            } while (año < 1 || año > 2024 || string.IsNullOrWhiteSpace(año.ToString()));

            Tesis nuevoTesis = new(titulo, autor, asesor, carrera, año);
            nuevaLista.Add(nuevoTesis);
            SetTesis(nuevaLista);

            Console.WriteLine("Proceso Exitoso!!!");
            Console.ReadKey();
        }

        public void buscarLibro()
        {
            if (GetLibros().Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.ReadKey();
                return;
            }

            string autor;
            List<Libro> porAutor = new();

            do
            {
                Console.WriteLine("Ingrese el autor del libro a buscar: ");
                autor = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(autor));

            for (int i = 0; i < GetLibros().Count; i++)
                if (GetLibros().ElementAt(i).GetAutores().Any(autor.Contains))
                    porAutor.Add(GetLibros().ElementAt(i));

            if (porAutor.Count > 0)
            {
                Console.WriteLine("Títulos de libro(s) por ese autor:");
                foreach (var i in porAutor)
                    Console.WriteLine("\n- " + i.GetTitulo());
            }
            else
                Console.WriteLine("No hay libros de ese autor en esta biblioteca.");
            Console.ReadKey();
        }

        public void buscarTesis()
        {

            if (GetTesis().Count == 0)
            {
                Console.WriteLine("No se encontraron tesis disponibles.");
                Console.ReadKey();
                return;
            }

            string autor;
            List<Tesis> porAutor = new();

            do
            {
                Console.WriteLine("Ingrese el autor de la tesis a buscar: ");
                autor = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(autor));

            for (int i = 0; i < GetTesis().Count; i++)
                if (GetTesis().ElementAt(i).GetAutores().Any(autor.Contains))
                    porAutor.Add(GetTesis().ElementAt(i));

            if (porAutor.Count > 0)
            {
                Console.WriteLine("Títulos de tesis por ese autor:");
                foreach (var i in porAutor)
                    Console.WriteLine("\n- " + i.GetTitulo());
            }
            else
                Console.WriteLine("No hay tesis de ese autor en esta biblioteca.");
            Console.ReadKey();
        }

        public void modificarLibro()
        {
            if (GetLibros().Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.ReadKey();
                return;
            }

            List<Libro> nuevaLista = GetLibros();
            string titulo, edit;
            int nAutor, ejemp, año;
            List<string> autor = new();
            List<string> isbn = new();

            do { Console.WriteLine("Ingrese el título del libro a modificar: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

             int posicion = nuevaLista.FindIndex(c => c.GetTitulo() == titulo);

            if (posicion == -1)
            {
                Console.WriteLine("No hay libros en la biblioteca con ese título.");
                Console.ReadKey();
                return;
            }

            do
            {
                Console.WriteLine("Ingrese el nuevo título del libro: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            do
            {
                Console.WriteLine("Ingrese la cantidad de autores del libro: ");
                nAutor = int.Parse(Console.ReadLine());
            } while (nAutor < 1||string.IsNullOrWhiteSpace(nAutor.ToString()));

            for (int i = 0; i < nAutor; i++)
            {
                string nuevoAutor;
                do
                {
                    Console.WriteLine("Ingrese el autor #" + i + " del libro: ");
                    nuevoAutor = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nuevoAutor));
                autor.Add(nuevoAutor);
            }

            do
            {
                Console.WriteLine("Ingrese la cantidad de ejemplares del libro: ");
                ejemp = int.Parse(Console.ReadLine());
            } while (ejemp<0 || string.IsNullOrWhiteSpace(ejemp.ToString()));

            for (int i = 0; i < ejemp; i++)
            {
                do
                {
                    Console.WriteLine("Ingrese el ISBN del ejemplar #{0} del libro", i + 1);
                    isbn.Add(Console.ReadLine());
                } while (string.IsNullOrWhiteSpace(isbn[i]));
            }

            do
            {
                Console.WriteLine("Ingrese la editorial del libro: ");
                edit = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(edit));

            do
            {
                Console.WriteLine("Ingrese el año del libro: ");
                año = int.Parse(Console.ReadLine());
            } while (año < 1 || año > 2024|| string.IsNullOrWhiteSpace(año.ToString()));

            Libro nuevoLibro = new(titulo, autor, ejemp, isbn, edit, año);
            nuevaLista[posicion] = nuevoLibro;
            SetLibros(nuevaLista);
        }
        public void modificarTesis()
        {

            if (GetTesis().Count == 0)
            {
                Console.WriteLine("No hay tesis en la biblioteca.");
                Console.ReadKey();
                return;
            }

            List<Tesis> nuevaLista = GetTesis();
            string titulo, carrera, asesor;
            int nAutor, año;
            List<string> autor = new List<string>();

            do
            {
                Console.WriteLine("Ingrese el título de la tesis a modificar: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            int posicion = nuevaLista.FindIndex(c => c.GetTitulo() == titulo);

            if (posicion == -1)
            {
                Console.WriteLine("No hay tesis en la biblioteca con ese título.");
                Console.ReadKey();
                return;
            }

            do 
            {
                Console.WriteLine("Ingrese el nuevo título de la tesis: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            do
            { Console.WriteLine("Ingrese la carrera de la tesis: ");
                carrera = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(carrera));

            do
            {
                Console.WriteLine("Ingrese el asesor de la tesis: ");
                asesor = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(asesor));

            do
            {
                Console.WriteLine("Ingrese la cantidad de autores de la tesis: ");
                nAutor = int.Parse(Console.ReadLine());
            } while (nAutor < 1 || string.IsNullOrWhiteSpace (nAutor.ToString()));

            for (int i = 0; i < nAutor; i++)
            {
                string nuevoAutor;
                do
                {
                    Console.WriteLine("Ingrese el autor #{0} de la tesis", i + 1);
                    nuevoAutor = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nuevoAutor));
                autor.Add(nuevoAutor);
            }

            do
            {
                Console.WriteLine("Ingrese el año de la tesis: ");
                año = int.Parse(Console.ReadLine());
            } while (año < 1 || año > 2024 || string.IsNullOrWhiteSpace (año.ToString()));

            Tesis nuevoTesis = new(titulo, autor, asesor, carrera, año);
            nuevaLista[posicion] = nuevoTesis;
            SetTesis(nuevaLista);

            Console.WriteLine("Proceso Exitoso!!!");
            Console.ReadKey();
        }
        public void eliminarLibro()
        {
            if (GetLibros().Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.ReadKey();
                return;
            }

            List<Libro> nuevaLista = GetLibros();
            string titulo;
            do
            {
                Console.WriteLine("Ingrese el título del libro a eliminar: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

            Libro eliminado = nuevaLista.SingleOrDefault(e => e.GetTitulo() == titulo);

            if (eliminado == null)
            {
                Console.WriteLine("No hay libros en la biblioteca con ese título.");
                Console.ReadKey();
                return;
            }

            nuevaLista.Remove(eliminado);
            SetLibros(nuevaLista);
        }
        public void eliminarEjemplar()
        {
            if (GetLibros().Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.ReadKey();
                return;
            }

            List<Libro> nuevaLista = GetLibros();
            string titulo;

            do
            {
                Console.WriteLine("Ingrese el título del ejemplar a eliminar: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(titulo));

             Libro eliminado = nuevaLista.SingleOrDefault(e => e.GetTitulo() == titulo);

            if (eliminado == null)
            {
                Console.WriteLine("No hay ejemplares en la biblioteca con ese título.");
                Console.ReadKey();
                return;
            }
            int position = nuevaLista.IndexOf(eliminado);
            nuevaLista[position].SetEjemplar(nuevaLista[position].GetEjemplar() - 1);
            if (nuevaLista[position].GetEjemplar() == 0)
            {
                nuevaLista.Remove(eliminado); 
            }
            SetLibros(nuevaLista);
        }
        public void procesarPréstamo()
        {
            if (GetLibros().Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                Console.ReadKey();
                return;
            }

            List<Libro> nuevaLista = GetLibros();
            string nombre, cédula, titulo, otro = "";
            int nPresto = 0;

            do
            { Console.WriteLine("Indique su nombre: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nombre));

            do
            {
                Console.WriteLine("Indique su cédula de identidad: ");
                cédula = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(cédula));
            do
            {
                do
                {
                    Console.WriteLine("Ingrese el título del libro que desea: ");
                    titulo = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(titulo));

                 Libro prestado = nuevaLista.SingleOrDefault(e => e.GetTitulo() == titulo);

                if (prestado == null)
                {
                    Console.WriteLine("No hay libros en la biblioteca con ese título.");
                    Console.ReadKey();
                }
                else
                {
                    int posicion = nuevaLista.FindIndex(c => c.GetTitulo() == titulo);

                    if (nuevaLista[posicion].GetEjemplar() == 0)
                    {
                        Console.WriteLine("No hay ejemplares de ese libro en la biblioteca.");
                        Console.ReadKey();
                    }
                    else
                    {
                        nuevaLista[posicion].SetEjemplar(nuevaLista[posicion].GetEjemplar() - 1);
                        nuevaLista[posicion].SetEstudiante(nombre);
                        nuevaLista[posicion].SetCédula(cédula);
                        nuevaLista[posicion].SetPresto(true);
                        SetLibros(nuevaLista);
                        nPresto++;

                        Console.WriteLine("Trámite exitoso, disfrute de su libro.");
                        Console.ReadKey();
                    }
                }

                if (nPresto < 3)
                {
                    Console.WriteLine("Presione 1 si desea otro libro: ");
                    otro = Console.ReadLine();
                }

            } while (otro == "1" || nPresto == 3);

        }
        public void procesarReintegro()
        {
            List<Libro> nuevaLista = GetLibros();
            string nombre, cédula, titulo, otro = "";


            do
            { Console.WriteLine("Indique su nombre: ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nombre));

            do 
            {
                Console.WriteLine("Indique su cédula de identidad: ");
                cédula = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace (cédula));

            do
            {
                Console.WriteLine("Ingrese el título del libro que desea reintegrar: ");
                titulo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace (titulo));

                Libro prestado = nuevaLista.SingleOrDefault(e => e.GetTitulo() == titulo);
                if (prestado == null)
                {
                    Console.WriteLine("No hay libros en la biblioteca con ese título.");
                    Console.ReadKey();
                }
                else
                {
                    int posicion = nuevaLista.FindIndex(c => c.GetTitulo() == titulo);

                    if (nuevaLista[posicion].GetPresto() == false)
                    {
                        Console.WriteLine("Ese libro nunca fue prestado.");
                        Console.ReadKey();
                    }
                    else
                    {
                        nuevaLista[posicion].SetEjemplar(nuevaLista[posicion].GetEjemplar() + 1);
                        nuevaLista[posicion].SetEstudiante(null);
                        nuevaLista[posicion].SetCédula(null);
                        nuevaLista[posicion].SetPresto(false);
                        SetLibros(nuevaLista);
                        

                        Console.WriteLine("Trámite exitoso!!");
                        Console.ReadKey();
                    }
                }
        }

        public void listadoLibros()
        {
            List<Libro> listado = new List<Libro>();
            listado = GetLibros();
            if (listado.Count > 0)
            {
                Console.WriteLine("Listado de libros: ");
               for (int i = 0; i < listado.Count; i++)
               {
                    Console.WriteLine("\n\n Titulo{0}: {1}", i+1, listado[i].GetTitulo());
                    for(int j=0; j< listado[i].GetAutores().Count; j++)
                    
                        Console.WriteLine("\n Autor {0}: {1}", j+1 , listado[i].GetAutores()[j]);
                        Console.WriteLine("\n Año: " + listado[i].GetAño().ToString());
                        Console.WriteLine("\n Ejemplares: " + listado[i].GetEjemplar().ToString());                    
               }
                
            }
            else
                Console.WriteLine("La biblioteca se encuentra vacia.");
            Console.ReadKey();
        }

        public void listadoPrestamos()
        {
            List<Libro> listado = new List<Libro>();
            listado = GetLibros();
            if (listado.Count > 0)
            {
                Console.WriteLine("Litado de prestamos: ");
                int cont = 0;
                for (int i = 0; i < listado.Count; i++)
                {
                    if (listado[i].GetPresto() == true)
                    {
                        Console.WriteLine("\n\n Al estudiante {0} se le presto el libro {1}: {2}", listado[i].GetEstudiante(), cont++, listado[i].GetTitulo());
                        for (int j = 0; j < listado[i].GetAutores().Count; j++)
                        Console.WriteLine("\n Autor: {0}: {1}", j, listado[i].GetAutores()[j]);
                        Console.WriteLine("\n Año: " + listado[i].GetAño().ToString());
                        Console.WriteLine("\n Ejemplares: " + listado[i].GetEjemplar().ToString());
                    }
                }
                if (cont == 0)
                {
                    Console.WriteLine("No hay libros prestados.");
                    Console.ReadKey();
                }


            }
            else
                Console.WriteLine("La biblioteca se encuentra vacia.");
            Console.ReadKey();
        }

        public void listadoTesis()
        {
            List<Tesis> listado = new List<Tesis>();
            listado = GetTesis();
            if (listado.Count > 0)
            {
                Console.WriteLine("Listado de tesis: ");
                for (int i = 0; i < listado.Count; i++)
                {
                    Console.WriteLine("\n\n Titulo{0}: {1}", i+1, listado[i].GetTitulo());
                    for (int j = 0; j < listado[i].GetAutores().Count; j++)
                    
                        Console.WriteLine("\n Autor {0}: {1}", j+1 , listado[i].GetAutores()[j]);
                        Console.WriteLine("\n Año: " + listado[i].GetAño().ToString());
                        Console.WriteLine("\n Carrera: " + listado[i].GetCarrera().ToString());                    
                }

            }
            else
                Console.WriteLine("La biblioteca se encuentra vacia.");
            Console.ReadKey();
        }

        public void listadoTesisAsesor()
        {

                List<Tesis> listadoAsesor = GetTesis();
                List<string> asesores = new();

                for (int i = 0; i < listadoAsesor.Count; i++)
                    if (!asesores.Contains(listadoAsesor[i].GetAsesor()))
                         asesores.Add(listadoAsesor[i].GetAsesor());

                if (asesores.Count > 0)
                {
                    Console.WriteLine("Tesis listados por asesor:");
                    for (int i = 0; i < asesores.Count; i++)
                    {
                        Console.WriteLine("\n\n Asesor {0}: {1}", i+1, asesores[i]);
                        for (int j = 0, k = 1; j < listadoAsesor.Count; j++)
                            if (listadoAsesor[j].GetAsesor() == asesores[i])
                                Console.WriteLine("\n Tesis {0} del Asesor\n Título: {1}", k++,
                                    listadoAsesor[j].GetTitulo());
                    }
                }
                else
                    Console.WriteLine("No hay tesis en esta biblioteca.");
                Console.ReadKey();
            
        }
    }
}

