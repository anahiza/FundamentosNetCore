using System.Collections.Generic;
using CoreEscuela.Entidades;
namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela escuela { get; set; }
        public EscuelaEngine()
        {
            
        }

        public void Inicializar(){
            escuela = new Escuela("Platzi School", 2012, TiposEscuela.Preescolar, pais: "Colombia");
        
            escuela.cursos = new List<Curso>(){
                new Curso(){ Nombre = "101",jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "201", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "301", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre="342", jornada= TiposJornada.Vespertino },
                new Curso(){ Nombre="483", jornada= TiposJornada.Vespertino },
                new Curso(){Nombre="101 Curso Vacacional", jornada=TiposJornada.Nocturno}
            };
        }
    }
}