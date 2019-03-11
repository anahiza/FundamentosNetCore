using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela escuela { get; set; }
        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            escuela = new Escuela("Platzi School", 2012, TiposEscuela.Preescolar, pais: "Colombia");

            CargarCursos();
            CargarAsignaturas();          
            CargarEvaluaciones();
            
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            var diccionario = new Dictionary<LlaveDiccionario,  IEnumerable<ObjetoEscuelaBase>>();
            var listTemp = new List<Evaluacion>();
            var listTempAlumno = new List<Alumno>();
            var listTempAsignatura= new List<Asignatura>();
            (listTemp, listTempAlumno, listTempAsignatura)=InicializarDiccionario();           
            diccionario.Add(LlaveDiccionario.Escuela, new[] { escuela });
            diccionario.Add(LlaveDiccionario.Curso, escuela.cursos.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listTempAlumno.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion, listTemp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listTempAsignatura.Cast<ObjetoEscuelaBase>());
            return diccionario;

        }

        private (List<Evaluacion>, List<Alumno>, List<Asignatura>) InicializarDiccionario()
        {
            var listTemp = new List<Evaluacion>();
            var listTempAlumno = new List<Alumno>();
            var listTempAsignatura= new List<Asignatura>();            
           foreach (var c in escuela.cursos)
           {
               listTempAlumno.AddRange(c.Alumnos);
               listTempAsignatura.AddRange(c.Asignaturas);
                foreach (var a in c.Asignaturas)
                {
                    listTemp.AddRange(a.Evaluaciones);
                }                
           }
        return (listTemp, listTempAlumno, listTempAsignatura);
        }

        private void CargarEvaluaciones()
        {
            foreach (var c in escuela.cursos)
            {
                foreach(var m in c.Asignaturas)
                {
                    m.Evaluaciones=new List<Evaluacion>();
                    foreach(var a in c.Alumnos)
                    {
                        var listaEvaluaciones = new List<Evaluacion>();
                        for(var i=0; i<5; i++)
                        {
                            Evaluacion e = new Evaluacion{ Alumno=a, Asignatura=m, Nombre = $"{i+1}.{m.Nombre}", Nota=GenerarNotaAleatoria() };
                            listaEvaluaciones.Add(e);
                        }
                        m.Evaluaciones.AddRange(listaEvaluaciones);
                        a.evaluaciones=listaEvaluaciones;
                    }
                }
            }
        }

        private float GenerarNotaAleatoria()
        {
            float nota;
            Random rnd = new Random();
            nota = (float) new Random().NextDouble() * 10;
            nota = MathF.Round(nota,2);

            return nota;
            
        }
    
#region cargas
    

        private void CargarAsignaturas()
        {
            foreach (var c in escuela.cursos){
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                c.Asignaturas= listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosalAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{Nombre=$"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy((a1)=> a1.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            escuela.cursos = new List<Curso>(){
                new Curso(){ Nombre = "101",jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "201", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre = "301", jornada = TiposJornada.Matutino },
                new Curso(){ Nombre="342", jornada= TiposJornada.Vespertino },
                new Curso(){ Nombre="483", jornada= TiposJornada.Vespertino }
               
            };

            Random rnd = new Random();
            
            foreach(var c in escuela.cursos)            
            {
                int cantidad = rnd.Next(5,20);
                c.Alumnos=GenerarAlumnosalAzar(cantidad);
            }
           
        }

#endregion

         public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int  conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos= true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            conteoAlumnos = conteoAsignaturas=conteoCursos=conteoEvaluaciones=0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);
            if (traeCursos)
            {
                listaObj.AddRange(escuela.cursos);
                conteoCursos+=escuela.cursos.Count();
            }
            foreach (var curso in escuela.cursos)
            {
                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                    conteoAlumnos+=curso.Alumnos.Count();

                }
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                    conteoAsignaturas+= curso.Asignaturas.Count();

                }
                if (traeEvaluaciones)
                {
                    foreach (var e in curso.Asignaturas)
                    {
                        
                        listaObj.AddRange(e.Evaluaciones);
                        conteoAsignaturas+=curso.Asignaturas.Count();
                    }

                }
            }


            return listaObj;
        }
    

    public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(            
            bool traeEvaluaciones = true,
            bool traeAlumnos= true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
                int dummy = 0;
                return GetObjetoEscuelas(out dummy, out dummy, out dummy,out dummy , traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);

            }

    }
}