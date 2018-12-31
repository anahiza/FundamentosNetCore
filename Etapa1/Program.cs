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
            
            
        }

        private static void ImprimirCursos(Escuela e)
        {
            Printer.DibujarTitulo(e.Nombre);
            foreach (var c in e.cursos)
            {
                c.imprimirCurso();
            }
            Printer.DibujarLinea(20);
        }

       
    }   


           
}

