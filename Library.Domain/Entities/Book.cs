
namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPage { get; set; }
        public DateTime PublishingDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookOrderId { get; set; }
        public BookOrder BookOrder { get; set; }
    }
}
