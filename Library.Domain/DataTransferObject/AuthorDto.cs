
namespace Library.Domain.DataTransferObject
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int NumberOfBook { get; set; }
        public DateTime BirthDate { get; set; }
        public List<BookDto>? Book { get; set; }
    }
}


