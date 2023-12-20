//Benjamin Castro Ceballos - Cuadrilateros

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuadrilateros__clase_16.Clases;
namespace Cuadrilateros__clase_16.Clases
{
    internal abstract class Cuadrilatero
    {
        private Punto A { get; set; }
        private Punto B { get; set; }
        private Punto C { get; set; }
        private Punto D { get; set; }

        public abstract int CalcularArea();
        internal class Cuadrado : Cuadrilatero
        {
            public Cuadrado(Punto A, Punto B, Punto C, Punto D)
            {
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
            }
            public override int CalcularArea()
            {

                Vector Vab = new Vector(); Vector vAD = new Vector();

                Vab.CalcularElementos(A, B); vAD.CalcularElementos(A, D); Vab.CalcularDistancia(); vAD.CalcularDistancia();

                int Area = (int)(Vab.Distancia * vAD.Distancia);

                return Area;

            }
        }
        internal class Rectangulo : Cuadrilatero
        {
            public Rectangulo(Punto A, Punto B, Punto C, Punto D)
            {
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
            }
            public override int CalcularArea()
            {
                Vector vAB = new Vector(); Vector vAD = new Vector();
                vAB.CalcularElementos(A, B); vAD.CalcularElementos(A, D); vAB.CalcularDistancia(); vAD.CalcularDistancia();
                int Area = (int)(vAB.Distancia * vAD.Distancia);
                return Area;
            }
        }
        internal class Trapecio : Cuadrilatero
        {
            public Trapecio(Punto A, Punto B, Punto C, Punto D)
            {
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
            }
            public override int CalcularArea()
            {
                Vector vAB = new Vector(); Vector vAD = new Vector(); Vector vDC = new Vector();

                vAB.CalcularElementos(A, B); vAD.CalcularElementos(A, D); vDC.CalcularElementos(D, C); vAB.CalcularDistancia(); vDC.CalcularDistancia();

                float Altura = (float)(Math.Sqrt(Math.Pow(vAD.Y,2)));

                int Area = (int)( (vAB.Distancia + vDC.Distancia) * Altura / 2);

                return Area;
            }
        }
    } 
}
