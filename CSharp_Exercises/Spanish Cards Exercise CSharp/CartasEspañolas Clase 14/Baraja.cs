//Benjamin Castro Ceballos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carta;
namespace CartasEspañolas_Clase_14
{
    
    internal class Baraja
    {
        public Stack<Cartas> Mazo = new();
        public List<Cartas> Monton = new();
       
        public void Barajar()
        {
          List<Cartas> MazoAlterno = new();
            for (int i = 0; i < Mazo.Count; i++)
            {
                MazoAlterno.Add( Mazo.Pop());
            }
            
            for (int i= 0; i< MazoAlterno.Count; i++)
            {
                Random Aleatorio = new();
                var CartaAnterior = new Cartas();

                int Lugar = Aleatorio.Next(0, (MazoAlterno.Count- 1));

                CartaAnterior =MazoAlterno[i];
                MazoAlterno.Remove(CartaAnterior);
                MazoAlterno.Insert(Lugar,CartaAnterior);
            }
            
            for (int i = 0; i < MazoAlterno.Count; i++)
            {
               Mazo.Push(MazoAlterno[i]) ;
            }
            MazoAlterno.Clear();
            Console.Clear();
        }
        public void Cargar(Cartas carga)
        {
            Mazo.Push(carga);
        }
        public void llenarMazo()
        {
           
            for (int j = 0; j < 4; j++)
            {

                for (int i = 1; i < 13; i++)
                {
                    if (i != 8 && i != 9)
                    {
                        Cartas cartaACargar = new();
                        switch (j)
                        {
                            case 0: cartaACargar.Palo = "♣"; break;
                            case 1: cartaACargar.Palo = "♦"; break;
                            case 2: cartaACargar.Palo = "♥"; break;
                            case 3: cartaACargar.Palo = "♠"; break;
                        }
                        cartaACargar.Numero = i;
                        Cargar(cartaACargar);
                    }
                }
            }
        }
        private void Mostrar( Cartas AGRAFICAR)
        {
            Console.WriteLine(" -------------------------------------- ");
            if (AGRAFICAR.Numero > 10) 
            Console.WriteLine($"| {AGRAFICAR.Numero}                                  |");
            else
                Console.WriteLine($"| {AGRAFICAR.Numero}                                    |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine($"|                   {AGRAFICAR.Palo}                  |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            if (AGRAFICAR.Numero > 10)
                Console.WriteLine($"|                                {AGRAFICAR.Numero}   |");
            else
                Console.WriteLine($"|                                 {AGRAFICAR.Numero}    |");
            Console.WriteLine("|______________________________________|");
            
        }
        
        public void SiguienteCarta()
        {
            var CartaMostrar = new Cartas();
            CartaMostrar = Mazo.Pop();
            Mostrar(CartaMostrar);
            Monton.Add(CartaMostrar);
            CartaMostrar = null;
            Console.ReadKey();
            Console.Clear();

        }
        public void CartasDisponibles()
        {
            Console.WriteLine($"Hay un total de {Mazo.Count} cartas disponibles");
            Console.ReadKey();
            Console.Clear();
        }
        public void DarCartas(int cantidad)
        {
            var CartaMostrar = new Cartas();

            do
            {
                if (cantidad <= Mazo.Count)
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        CartaMostrar = Mazo.Pop();
                        Mostrar(CartaMostrar);
                        Monton.Add(CartaMostrar);
                        Console.WriteLine(" ");
                    }
                }
                else
                    Console.WriteLine("No hay esa cantidad de cartas");
                Console.ReadKey();
                Console.Clear();
            }
            while (cantidad > Mazo.Count);
            
           
        }
        public void CartasMonton()
        {
            for(int i = 0; i < Monton.Count; i++)
            {
                Mostrar(Monton[i]);
                Console.WriteLine(" ");
            }
            Console.ReadKey();
            Console.Clear ();
        }
        public void MostrarBaraja()
        {
            List<Cartas> MazoALTERNO = new();
            for (int i = 0; i < Mazo.Count; i++)
            {
                MazoALTERNO.Add(Mazo.Pop());
            }
            for(int i = 0; i < MazoALTERNO.Count; i++)
            {
                Mostrar(MazoALTERNO[i]);
                Console.WriteLine(" ");
            }
            for (int i = 0; i < MazoALTERNO.Count; i++)
            {
             Mazo.Push(MazoALTERNO[i]);
            }
            Console.ReadKey();
            Console.Clear();
            MazoALTERNO.Clear();
        }
    }
 
}