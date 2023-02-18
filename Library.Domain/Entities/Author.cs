
namespace Library.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int NumberOfBook { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Book { get; set; }
    }
}
