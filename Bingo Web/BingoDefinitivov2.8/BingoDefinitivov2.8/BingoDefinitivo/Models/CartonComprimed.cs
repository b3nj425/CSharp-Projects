namespace BingoDefinitivo.Models
{
    public class CartonComprimed
    {
       public List<int> Carton { get; set; }
       public List<bool> Aciertos { get; set; }
        public CartonComprimed()
        {
            Carton = new List<int>();
            Aciertos = new List<bool>();
        }
    }
}
