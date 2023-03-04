
namespace Library.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public List<Order> Order { get; set; }
        public Address Address { get; set; }

    }
}
