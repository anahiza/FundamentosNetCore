using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

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
            _diccionario[LlaveDiccionario.Evaluacion];
        }
    }
}