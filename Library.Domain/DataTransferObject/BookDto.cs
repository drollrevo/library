

namespace Library.Domain.DataTransferObject
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPage { get; set; }
        public DateTime PublishingDate { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto? Author { get; set; }
        public int BookOrderId { get; set; }
        public BookOrderDto? BookOrder { get; set; }
    }
}