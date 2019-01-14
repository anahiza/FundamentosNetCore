using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;

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

            var alumnoTest = new Alumno {Nombre="Claire UnderWood"};
            ObjetoEscuelaBase ob = alumnoTest;
           

            var evaluacion = new Evaluacion{Nombre="Evaluacion de mat", Nota=8};
            WriteLine(evaluacion.UniqueId);
            ob = evaluacion;
            var listaObjetos = engine.GetObjetoEscuelas(traeEvaluaciones:false, traeAlumnos: false, traeAsignaturas:false);
            /* var listaIlugar = from obj in listaObjetos
                            where obj is Alumno
                            select (Alumno) obj; */
            engine.escuela.LimpiarLugar();
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

