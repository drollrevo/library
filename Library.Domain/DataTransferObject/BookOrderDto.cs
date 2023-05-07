
namespace Library.Domain.DataTransferObject
{
    public class BookOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDto? Order { get; set; }
        public List<BookDto> Book { get; set; }
    }
}
