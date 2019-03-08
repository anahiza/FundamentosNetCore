using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10){
            var linea = "".PadLeft(tam,'-');
            WriteLine(linea);  
        }

        public static void DibujarTitulo(string titulo){
            var tamano = titulo.Length+4;
            DrawLine(tamano);
            WriteLine($"| {titulo} |");
            DrawLine(tamano);

        }

        public static void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> d)
        {
            foreach (var obj in d)
            {
                DibujarTitulo(obj.Key.ToString());
                foreach (var item in obj.Value)
                {
                    WriteLine($"{item}");
                }           

            }
        }

        public static void Beep_(int hertz = 2000, int time= 500, int cantidad = 1){
            while(cantidad-- > 0)
            {
                System.Console.Beep(hertz,time);
            }
        }

        internal static void ImprimirAlumno(Alumno a)
        {
            Printer.DrawLine(a.Nombre.Length);
            WriteLine($"{a.Nombre} - {a.UniqueId}");
            WriteLine($"{a.GetType()} - {a.GetHashCode()}");
        }

        internal static void ImprimirInformacionEscuela(Escuela escuela)
        {
            DibujarTitulo(escuela.Nombre);
            WriteLine($"{escuela.AñoCreacion}, {escuela.Ciudad}, {escuela.Pais}");
            foreach(var c in escuela.cursos)
            {
                WriteLine($"{c.Nombre} - {c.UniqueId}");
                foreach(var a in c.Alumnos)
                {
                    WriteLine($"{a.Nombre} - {a.UniqueId}");
                    foreach(var m in c.Asignaturas)
                    {                        
                        WriteLine($"{m.Nombre}");
                        float promedio = 0;
                        foreach(var e in m.Evaluaciones)
                        {
                            if(e.Alumno.UniqueId==a.UniqueId){
                                Write($"{e.Nota} | ");
                                promedio+=e.Nota;
                            }    
                        }
                        promedio=promedio/5;                        
                        WriteLine($"Promedio: {promedio}");
                    }
                    DrawLine(50);
                }
            }
        }

        public static void ImprimirAlumnosCurso(List<Curso> cursos)
        {
            foreach (var c in cursos)
            {
                WriteLine($"Curso: {c.Nombre} - {c.UniqueId}");
                foreach( var a in c.Alumnos)
                {
                    WriteLine($"{a.UniqueId} - {a.Nombre}");
                }
                WriteLine("---");
            }
        }
    }
}