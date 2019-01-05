using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10){
            var linea = "".PadLeft(tam,'-');
            WriteLine(linea);  
        }

        public static void DibujarTitulo(string titulo){
            var tamano = titulo.Length+4;
            DibujarLinea(tamano);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamano);

        }

        public static void Beep_(int hertz = 2000, int time= 500, int cantidad = 1){
            while(cantidad-- > 0)
            {
                System.Console.Beep(hertz,time);
            }
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
                    DibujarLinea(50);
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