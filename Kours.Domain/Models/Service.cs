namespace Kours.Domain
{
    public class Service
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public LinkedList<Zakaz> Zakaz { get; set; } 
    }
}
