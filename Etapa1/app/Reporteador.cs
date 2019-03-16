using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela


{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> d)
        {
            if (d==null)
            {
                throw new ArgumentNullException(nameof(d));
            }
            _diccionario=d;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            IEnumerable <Evaluacion> rta;
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
               return rta = lista.Cast<Evaluacion>();
            }
            else
            {
               return new List<Evaluacion>();            }
          
            
            
        }
        public IEnumerable<string> GetListaAsignaturas()
        {            
            
            return GetListaAsignaturas(out var dummy);
            
        }

        public IEnumerable<string> GetListaAsignaturas( out IEnumerable<Evaluacion> listaEvaluaciones)
        {            
            listaEvaluaciones = GetListaEvaluaciones();
            return (from ev in listaEvaluaciones                
                select ev.Asignatura.Nombre).Distinct();  
            
        }

        public Dictionary<string,IEnumerable<Evaluacion>> GetListaEvaluacionesporAsignatura()
        {            
            var dicResult = new Dictionary<string,IEnumerable<Evaluacion>>();
            var listaAsignaturas = GetListaAsignaturas(out var listaEval);
            foreach (var asig in listaAsignaturas)
            {
                var evalAsig = from eval in listaEval
                            where eval.Asignatura.Nombre==asig
                            select eval;
                dicResult.Add(asig, evalAsig);
            }

            return dicResult;
        }

        public  Dictionary<string,IEnumerable<object>> GetPromedioAlumnosporAsignatura()
        {
            var res = new Dictionary<string,IEnumerable<object>>();
            var dicEvalxAsig = GetListaEvaluacionesporAsignatura();
            foreach(var asigconEval in dicEvalxAsig)
            {
                var promediosAlumnos = from eval in asigconEval.Value
                            group eval by eval.Alumno.UniqueId
                            into grupoEvalAlumno                            
                            select new AlumnoPromedio {
                                alumnoID = grupoEvalAlumno.Key,
                                promedio = grupoEvalAlumno.Average((evaluacion)=> evaluacion.Nota)
                                };
                 
                res.Add(asigconEval.Key,promediosAlumnos);
                
            }
            return res;
        }
    }
}