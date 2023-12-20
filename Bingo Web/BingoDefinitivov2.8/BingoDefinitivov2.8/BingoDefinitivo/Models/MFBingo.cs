using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BingoDefinitivo.Models
{
    public class MFBingo
    {
        public BingoCViewModel BingoDatos { get; set; }
        public CartonBingo Carton1 { get; set; }
        public CartonBingo Carton2 { get; set; }
        public CartonBingo Carton3 { get; set; }
        public CartonBingo Carton4 { get; set; }
        private List<int> Ganadores = new();
        public MFBingo()
        {
            Carton1 = new CartonBingo();
            Carton2 = new CartonBingo();
            Carton3 = new CartonBingo();
            Carton4 = new CartonBingo();

        }
        public MFBingo(BingoComprimed BingoComprimido)
        {
            Carton1 = new CartonBingo(BingoComprimido.Carton1);
            Carton2 = new CartonBingo(BingoComprimido.Carton2);
            Carton3 = new CartonBingo(BingoComprimido.Carton3);
            Carton4 = new CartonBingo(BingoComprimido.Carton4);
            HayGanador();
        }
      public void Jugar(int Numero)
      {
         

           Carton1.Chequeo(Numero);
           Carton2.Chequeo(Numero);
           Carton3.Chequeo(Numero);
           Carton4.Chequeo(Numero);
      }
        public bool HayGanador()
        {if (Carton1.EsGanador || Carton2.EsGanador || Carton3.EsGanador || Carton4.EsGanador)
            {
                BingoDatos = new BingoCViewModel();
                BingoDatos.Carton2 = null;
                BingoDatos.Carton3 = null;
                BingoDatos.Carton4 = null;
                if (Carton1.EsGanador)
                {
                    Ganadores.Add(1);
                   
                }
               if (Carton2.EsGanador)
                {
                    Ganadores.Add(2);
                }
               if (Carton3.EsGanador)
                {
                    Ganadores.Add(3);
                }
               if (Carton4.EsGanador)
                {
                    Ganadores.Add(4);
                }
                switch (Ganadores.Count)
                {
                    case 1: BingoDatos.Carton1 = Ganadores[0] ; break; 
                    case 2:
                        BingoDatos.Carton1 = Ganadores[0];
                        BingoDatos.Carton2 = Ganadores[1]; break;
                    case 3:
                        BingoDatos.Carton1 = Ganadores[0];
                        BingoDatos.Carton2 = Ganadores[1];
                        BingoDatos.Carton3 = Ganadores[2]; break;
                    case 4:
                        BingoDatos.Carton1 = Ganadores[0];
                        BingoDatos.Carton2 = Ganadores[1];
                        BingoDatos.Carton3 = Ganadores[2];
                        BingoDatos.Carton4 = Ganadores[3]; break;
                }
                Ganadores.Clear();
               BingoDatos.fecha = DateTime.Now; 
            }

                return (Carton1.EsGanador || Carton2.EsGanador || Carton3.EsGanador || Carton4.EsGanador);
        }
        public BingoComprimed COMPRIMIR()
        {
            CartonComprimed _carton1 = Carton1.ToSimple();
            CartonComprimed _carton2 = Carton2.ToSimple();
            CartonComprimed _carton3 = Carton3.ToSimple();
            CartonComprimed _carton4 = Carton4.ToSimple();
            BingoComprimed BingoComprimido = new()
            {
                Carton1 = _carton1,
                Carton2 = _carton2,
                Carton3 = _carton3,
                Carton4 = _carton4,
            };
         
            return BingoComprimido;
            
    }
    }
   
}
