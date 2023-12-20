using CartasEspañolas_Clase_14;
using Carta;

Baraja MIbaraja=new();

Cartas cartaacargar =new();

 int opcion;

MIbaraja.llenarMazo();
do
{
    Console.WriteLine("|Baraja De Cartas|");
    Console.WriteLine("1 - Barajar");
    Console.WriteLine("2 - Mostrar siguiente carta");
    Console.WriteLine("3 - Mostrar cartas disponibles");
    Console.WriteLine("4 - Dar cartas");
    Console.WriteLine("5 - Mostrar cartas del monton");
    Console.WriteLine("6 - Mostrar baraja");
    Console.WriteLine("7 - Salir");

    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1: MIbaraja.Barajar(); break;
        case 2: MIbaraja.SiguienteCarta(); break;
        case 3: MIbaraja.CartasDisponibles(); break;
        case 4:  Console.WriteLine("¿Cuantas cartas quiere? ");
            int cantidad=int.Parse(Console.ReadLine());
            MIbaraja.DarCartas(cantidad);break;
        case 5: MIbaraja.CartasMonton();break;
        case 6: MIbaraja.MostrarBaraja();break;
        case 7: Console.WriteLine("Salida con exito"); break;
            default: Console.WriteLine("Ingrese una opcion válida");break;

    }
} while (opcion != 7);