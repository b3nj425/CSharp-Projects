using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuadrilateros__clase_16.Clases
{
    internal class Punto
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    internal class Vector: Punto
    {
        public float Distancia { get; set; }

        public void CalcularElementos(Punto A, Punto B)
        {
            X= B.X-A.X;
            Y= B.Y-A.Y;
        }
        public void CalcularDistancia()
        {
            Distancia = (float)(Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)));
        }
    }
}
