namespace Kours.Domain
{
    public class StoreAddress
    {
        public int Id { get; set; }

        public string Store_address { get; set; }
        public LinkedList<Zakaz> Zakaz { get; set; }
    }
}
