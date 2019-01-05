using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno:ObjetoEscuelaBase
    {        
        public List<Evaluacion> evaluaciones {get ; set;}        
    }
}