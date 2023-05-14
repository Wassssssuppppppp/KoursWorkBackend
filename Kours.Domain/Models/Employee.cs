namespace Kours.Domain
{
    public class Employee
    {
        public int Id { get; set; }

        public string FIOemployee { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
        public LinkedList<Zakaz> Zakaz { get; set; }
    }
}
