using System;

namespace Escuela
{
    class Escuela
    {
        public string Nombre;
        public string Direccion;
        public int FundYear;
        public string ceo ;
        public void timbrar()
        {
            Console.Beep(2000,3000);
        }

    }   
    
    class Program
    {
        static void Main(string[] args)
        {
            var escuela1 = new Escuela();               
            escuela1.FundYear=1983;
            escuela1.Nombre="Mi escuela";
            escuela1.Direccion="oreaguireoghj eroirejg";
            escuela1.timbrar();
            Console.WriteLine("mi escuela"+ escuela1.Nombre);
        }
    }
}
