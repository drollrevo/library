
namespace Library.Domain.DataTransferObject
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto? Employee { get; set; }
        public ClientDto? Client { get; set; }
    }
}
