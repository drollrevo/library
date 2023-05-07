
namespace Library.Domain.DataTransferObject
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public List<OrderDto>? Order { get; set; }
        public List<AddressDto>? Address { get; set; }
    }
}
