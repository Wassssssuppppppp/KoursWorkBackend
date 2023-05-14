namespace Kours.Domain
{
    public class Post
    {
        public int Id { get; set; }

        public string TitleOfThePosition { get; set; }
        public LinkedList<Employee> Employee { get; set; } 
    }
}
