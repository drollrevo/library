
namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Number_of_page { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
