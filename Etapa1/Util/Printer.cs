using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10){
            var linea = "".PadLeft(tam,'-');
            WriteLine(linea);  
        }

        public static void DibujarTitulo(string titulo){
            var tamano = titulo.Length+4;
            DibujarLinea(tamano);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamano);

        }

        public static void Beep_(int hertz = 2000, int time= 500, int cantidad = 1){
            while(cantidad-- > 0)
            {
                System.Console.Beep(hertz,time);
            }
        }
    }
}