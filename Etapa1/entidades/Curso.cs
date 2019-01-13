using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {
        
        public TiposJornada jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string Direccion { get; set; }

        public void imprimirCurso()
        {
            Console.WriteLine($"Nombre: {Nombre} \t ID: {UniqueId} Jornada: {jornada}");
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento");
            Console.WriteLine($"Curso {Nombre} está limpio");
        }
    }

    
}