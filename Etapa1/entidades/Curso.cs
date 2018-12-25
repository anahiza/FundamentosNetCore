using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string id { get; private set; }
        public TiposJornada jornada { get; set; }

        public Curso()
        {
            id = Guid.NewGuid().ToString();
        }

        public void imprimirCurso()
        {
            Console.WriteLine($"Nombre: {Nombre} \t ID: {id} Jornada: {jornada}");
        }
    }

    
}