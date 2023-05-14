using Kours.Domain.Models;

namespace Kours.Domain
{
    public class Zakaz
    {
        public int Id { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? ServiceId { get; set; }
        public Service? Service { get; set; }

        public int? StoreAddressesId { get; set; }
        public StoreAddress? StoreAddresses { get; set; }

        public string? Status { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
