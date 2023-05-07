
namespace Library.Domain.DataTransferObject
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Build { get; set; }
        public List<ClientDto>? Client { get; set; }
    }
}
