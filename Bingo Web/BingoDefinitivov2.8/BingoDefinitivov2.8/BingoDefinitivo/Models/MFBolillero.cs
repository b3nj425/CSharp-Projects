using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoDefinitivo.Data;
namespace BingoDefinitivo.Models
{
    public class MFBolillero
    {
   
        //VIEWMODEL COMO MODELO A SUBIR EN BASE DE DATOS
        public BolilleroViewModel BolillaDatos { get; set; }
        private Random Aleatorio = new();
        public int Dar( List<int> listaRecibida)
        {
            int NumeroADar = Aleatorio.Next(0, 90);
            if (listaRecibida.Count == 0)
            {
                return NumeroADar;
            }
            else
            {
                foreach (int numero in listaRecibida)
                {

                    if (NumeroADar == numero)
                    {
                        do
                            NumeroADar = Aleatorio.Next(0, 90);
                        while (listaRecibida.Contains(NumeroADar));
                    }
                }
                return NumeroADar;
            }
      
        }
    
      
    }
}
