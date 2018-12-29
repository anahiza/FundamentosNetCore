using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            ImprimirCursos(engine.escuela);
        }

        private static void ImprimirCursos(Escuela e)
        {
            WriteLine(e.ToString());
            WriteLine("***********");
            foreach (var c in e.cursos)
            {
                c.imprimirCurso();
            }
        }

       
    }   


           
}

