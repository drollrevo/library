
namespace Library.Domain.DataTransferObject
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public List<OrderDto> Order { get; set; }
    }
}
