using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGRAMABIBLIOTECA
{
    class Tesis
    {
        // Atributos


        // Constructor de la clase
        public Tesis() { }


        // Atributos
        protected string Titulo { get; set; }
        protected List<string> Autor { get; set; }
        protected int Año { get; set; }
        protected string Asesor { get; set; }
        protected string Carrera { get; set; }

        // Constructor de la clase

        public Tesis(string titulo, List<string> autor, string Asesor, string Carrera, int año)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Año = año;
            this.Asesor = Asesor;
            this.Carrera = Carrera;
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
        public string GetAsesor()
        {
            return Asesor;
        }
        public void SetEstudiante(string Asesor)
        {
            Asesor = Asesor;
        }
        public string GetCarrera()
        {
            return Carrera;
        }
        public void setCarrera(string cédula)
        {
            Carrera = Carrera;
        }
    
    }
}