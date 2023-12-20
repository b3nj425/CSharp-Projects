//Benjamin Castro Ceballos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Billetera
{
    internal class Billetera
    {
        public int BilletesDe10 { get; set; }
        public int BilletesDe20 { get; set; }
        public int BilletesDe50 { get; set; }
        public int BilletesDe100 { get; set; }
        public int BilletesDe200 { get; set; }
        public int BilletesDe500 { get; set; }
        public int BilletesDe1000 { get; set; }

        public decimal Total()
        {
            decimal total = 0; int suma;
            suma = (BilletesDe10 * 10) + (BilletesDe20 * 20) + (BilletesDe50 * 50) + (BilletesDe100 * 100) + (BilletesDe200 * 200) + (BilletesDe500 * 500) + (BilletesDe1000 * 1000);
            total = Convert.ToDecimal(suma);
            return total;
        }
        public Billetera Combinar(Billetera Acombinar)
        {
            var BilleteraResultado = new Billetera();
            BilleteraResultado.BilletesDe10 = Acombinar.BilletesDe10 + BilletesDe10;
            BilleteraResultado.BilletesDe20 = Acombinar.BilletesDe20 + BilletesDe20;
            BilleteraResultado.BilletesDe50 = Acombinar.BilletesDe50 + BilletesDe50;
            BilleteraResultado.BilletesDe100 = Acombinar.BilletesDe100 + BilletesDe100;
            BilleteraResultado.BilletesDe200 = Acombinar.BilletesDe200 + BilletesDe200;
            BilleteraResultado.BilletesDe500 = Acombinar.BilletesDe500 + BilletesDe500;
            BilleteraResultado.BilletesDe1000 = Acombinar.BilletesDe1000 + BilletesDe1000;

            BilletesDe10 = 0;
            BilletesDe20 = 0;
            BilletesDe50 = 0;
            BilletesDe100 = 0;
            BilletesDe200 = 0;
            BilletesDe500 = 0;
            BilletesDe1000 = 0;

            Acombinar.BilletesDe10 = 0;
            Acombinar.BilletesDe20 = 0;
            Acombinar.BilletesDe50 = 0;
            Acombinar.BilletesDe100 = 0;
            Acombinar.BilletesDe200 = 0;
            Acombinar.BilletesDe500 = 0;
            Acombinar.BilletesDe1000 = 0;
            
            return BilleteraResultado;
        }
    }
}

