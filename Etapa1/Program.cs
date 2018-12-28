using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela1 = new Escuela("Platzi School", 2012, TiposEscuela.Preescolar, pais: "Colombia");     
            new Escuela("Platzi School", 2012, TiposEscuela.Preescolar) ;
            escuela1.TipoEscuela = TiposEscuela.Primaria;
            var listaCursos = new List<Curso>(){
                 new Curso() {  Nombre = "101",jornada = TiposJornada.Matutino

            },
            new Curso()
            {
                Nombre = "201",
                jornada = TiposJornada.Matutino

            },
            new Curso()
            {
                Nombre = "301",
                jornada = TiposJornada.Matutino

            }
            };
            escuela1.cursos=listaCursos;
            ImprimirCursos(escuela1);

            escuela1.cursos.Add(new Curso(){
                Nombre= "201",
                jornada= TiposJornada.Vespertino
            });

            var otraColeccion = new List<Curso>() {
                new Curso(){ Nombre="342", jornada= TiposJornada.Vespertino },
                new Curso(){ Nombre="483", jornada= TiposJornada.Vespertino }
            };

            escuela1.cursos.AddRange(otraColeccion);
            Curso tmp = new Curso(){Nombre="101 Curso Vacacional", jornada=TiposJornada.Nocturno};
            escuela1.cursos.Add(tmp);
            ImprimirCursos(escuela1);    
            
            escuela1.cursos.RemoveAll((c) => c.Nombre=="301" && c.jornada==TiposJornada.Matutino);
            escuela1.cursos.Remove(tmp);
            ImprimirCursos(escuela1);
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

