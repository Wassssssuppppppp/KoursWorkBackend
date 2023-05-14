namespace Kours.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int SkladId { get; set; }
        public Sklad? Sklad { get; set; }
        public string Title { get; set; }

        public decimal PricePerPiece { get; set; }
        public int? ZakazOrderCode { get; set; }
        public LinkedList<Zakaz> Zakaz { get; set; } 
    }
}
