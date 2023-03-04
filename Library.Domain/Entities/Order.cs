
namespace Library.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }
    }
}
