using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones {get; set;}
        
    }
}