namespace BingoDefinitivo.Models
{
    public class BingoComprimed
    {
        public CartonComprimed Carton1 { get; set; }
        public CartonComprimed Carton2 { get; set; }
        public CartonComprimed Carton3 { get; set; }
        public CartonComprimed Carton4 { get; set; }
        public BingoComprimed()
        {
            CartonComprimed Carton1 = new();
            CartonComprimed Carton2 = new();
            CartonComprimed Carton3 = new();
            CartonComprimed Carton4 = new();
        }

    }
}
