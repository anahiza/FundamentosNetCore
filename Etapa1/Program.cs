using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.DibujarTitulo("Bienvenidos a la escuela");
            Printer.ImprimirInformacionEscuela(engine.escuela);
            Printer.DibujarTitulo("Pruebas de Polimorfismo");
            var alumnoTest = new Alumno {Nombre="Claire UnderWood"};
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.ImprimirAlumno(alumnoTest);
           
            Console.WriteLine($"{ob.GetType()} - {ob.UniqueId} {ob.GetHashCode()}");
            
        }

        private static void ImprimirCursos(Escuela e)
        {
            Printer.DibujarTitulo(e.Nombre);
            foreach (var c in e.cursos)
            {
                c.imprimirCurso();
            }
            Printer.DrawLine(20);
        }

       
    }   


           
}

