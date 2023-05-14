using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Sklad
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int quantity { get; set; }
        public LinkedList<Product> Product { get; set; }
    }
}
