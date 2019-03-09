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
            AppDomain.CurrentDomain.ProcessExit += AccionEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,s)=> WriteLine("salio");
            AppDomain.CurrentDomain.ProcessExit -= AccionEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.DibujarTitulo("Bienvenidos a la escuela");
            Printer.ImprimirInformacionEscuela(engine.escuela);

            var alumnoTest = new Alumno {Nombre="Claire UnderWood"};
            ObjetoEscuelaBase ob = alumnoTest;
           

            var evaluacion = new Evaluacion{Nombre="Evaluacion de mat", Nota=8};
            WriteLine(evaluacion.UniqueId);
            ob = evaluacion;
            // var listaObjetos = engine.GetObjetoEscuelas(
            // traeEvaluaciones:false, traeAlumnos: true, traeAsignaturas:false);
            // /* var listaIlugar = from obj in listaObjetos
            //                 where obj is Alumno
            //                 select (Alumno) obj; */
            // engine.escuela.LimpiarLugar();

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(1,"Juan");
            diccionario.Add(23, "Lorem ipsum");
            foreach (var keyValPair in diccionario)
            {
                Console.WriteLine($"Key: {keyValPair.Key} Value: {keyValPair.Value}");
            }

            Printer.DibujarTitulo("Acceso a Diccionario");
            WriteLine(diccionario[23]);
            Printer.DibujarTitulo("Otro diccionario");
            Dictionary<string, string> diccionario2 = new Dictionary<string, string>();
            diccionario2["Luna"]="Cuerpo celeste que gira";
           
            WriteLine(diccionario2["Luna"]);
            Printer.DibujarTitulo("Diccionario");
            var dic=engine.GetDiccionarioObjetos();
            Printer.ImprimirDiccionario(dic,true, false,false);
            
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

