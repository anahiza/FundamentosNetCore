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
            
            AppDomain.CurrentDomain.ProcessExit += (o,s)=> WriteLine("salio");
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.DibujarTitulo("Bienvenidos a la escuela");
            Printer.ImprimirInformacionEscuela(engine.escuela);

            // var alumnoTest = new Alumno {Nombre="Claire UnderWood"};
            // ObjetoEscuelaBase ob = alumnoTest;
           

            // var evaluacion = new Evaluacion{Nombre="Evaluacion de mat", Nota=8};
            // WriteLine(evaluacion.UniqueId);
            // ob = evaluacion;
            // var listaObjetos = engine.GetObjetoEscuelas(
            // traeEvaluaciones:false, traeAlumnos: true, traeAsignaturas:false);
            // /* var listaIlugar = from obj in listaObjetos
            //                 where obj is Alumno
            //                 select (Alumno) obj; */
            // engine.escuela.LimpiarLugar();                     
            
            
            Printer.DibujarTitulo("Diccionario");
            var dic=engine.GetDiccionarioObjetos();
            //Printer.ImprimirDiccionario(dic,true, false,false);
            var reporteador = new Reporteador(dic);
            var evallist=reporteador.GetListaEvaluaciones();
            var listaasignaturas = reporteador.GetListaAsignaturas();
            var listaEvalxAsig =reporteador.GetListaEvaluacionesporAsignatura();
            var listaCalificaciones = reporteador.GetPromedioAlumnosporAsignatura();
            foreach item in listaCalificaciones
            {
                foreach (var alumno in item.Value)
                {
                    var tmp=alumno as Alumno;
                    if (tmp)
                }
            
            }
        }

        private static void AccionEvento(object sender, EventArgs e)
        {
           Printer.DibujarTitulo("Saliendo");
           Printer.Beep_(3000,1000,3);
           Printer.DibujarTitulo("Salió");
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

