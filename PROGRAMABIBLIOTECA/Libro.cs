using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMABIBLIOTECA
{
     class Libro
    {
        // Atributos
        protected string Titulo { get; set; }
        protected List<string> Autor { get; set; }
        protected int Ejemplares { get; set; }
        protected List<string> ISBN { get; set; }
        protected string Editorial { get; set; }
        protected int Año { get; set; }
        protected string Estudiante { get; set; }
        protected string Cédula { get; set; }
        protected bool prestado { get; set; }
        // Constructor de la clase
       // public Libro() { }

        public Libro(string titulo, List<string> autor, int ejemp, List<string> isbn, string edit, int año)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Ejemplares = ejemp;
            this.ISBN = isbn;
            this.Editorial = edit;
            this.Año = año;
            this.Estudiante = null;
            this.Cédula = null;
        }

        // Métodos de Get Set
        public string GetTitulo()
        {
            return Titulo;
        }
        public void SetTitulo(string titulo)
        {
            Titulo = titulo;
        }
        public List<string> GetAutores()
        {
            return Autor;
        }
        public void SetAutores(List<string> autor)
        {
            Autor = autor;
        }
        public int GetAño()
        {
            return Año;
        }
        public void SetAño(int año)
        {
            año = año;
        }
        public int GetEjemplar()
        {
            return Ejemplares;
        }
        public void SetEjemplar(int ejemplar)
        {
            Ejemplares = ejemplar;
        }
        public string GetEstudiante()
        {
            return Estudiante;
        }
        public void SetEstudiante(string estudiante)
        {
            Estudiante = estudiante;
        }
        public string GetCédula()
        {
            return Cédula;
        }
        public void SetCédula(string cédula)
        {
            Cédula = cédula;
        }
        public bool GetPresto()
        {
            return prestado;
        }
        public void SetPresto(bool presto)
        {
            prestado = presto;
        }
     }
   
}
