using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela escuela { get; set; }
        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            escuela = new Escuela("Platzi School", 2012, TiposEscuela.Preescolar, pais: "Colombia");

            CargarCursos();
            CargarAsignaturas();
          
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var c in escuela.cursos){
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                c.Asignaturas= listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosalAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{Nombre=$"(n1) (n2) (a1)"};
            return listaAlumnos.OrderBy((a1)=> a1.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            escuela.cursos = new List<Curso>(){
                new Curso(){ Nombre = "101",jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "201", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "301", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre="342", jornada= TiposJornada.Vespertino },
                new Curso(){ Nombre="483", jornada= TiposJornada.Vespertino },
                new Curso(){Nombre="101 Curso Vacacional", jornada=TiposJornada.Nocturno}
            };

            Random rnd = new Random();
            
            foreach(var c in escuela.cursos)            
            {
                int cantidad = rnd.Next(5,20);
                c.Alumnos=GenerarAlumnosalAzar(cantidad);
            }
        }
    }
}