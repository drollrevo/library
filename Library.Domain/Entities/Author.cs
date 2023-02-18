
namespace Library.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public List<Book> Book { get; set; }
    }
}
