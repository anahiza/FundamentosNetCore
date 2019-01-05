using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase
    {
        
        public TiposJornada jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        public void imprimirCurso()
        {
            Console.WriteLine($"Nombre: {Nombre} \t ID: {UniqueId} Jornada: {jornada}");
        }
    }

    
}