using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public List<Evaluacion> Evaluaciones {get; set;}

        public Asignatura() => UniqueId = Guid.NewGuid().ToString();
    }
}