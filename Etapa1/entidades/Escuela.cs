using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre { 
            get{ return nombre; }
            set{ nombre = value.ToUpper(); } 
            }
        public int AñoCreacion { get; set; }
        public string Pais { get; set; }    
        public string Ciudad { get; set; }
/* 
        public Escuela(string value, int year){
            this.nombre = value;
            AñoCreacion = year;
        } */
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> cursos { get; set; }

        public Escuela (string value, int year) => (this.Nombre, this.AñoCreacion) = (value, year);

        public Escuela (string value, int year, TiposEscuela tipo, string pais = "", string ciudad = "") 
        {
           ( Nombre, AñoCreacion, TipoEscuela ) = (value,  year,  tipo) ;
           Pais = pais;
           Ciudad = ciudad;

        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo {TipoEscuela} \nPais {Pais}, Ciudad {Ciudad}";
        }
    }
}