namespace Library.Domain.Entities
{
    public class BookOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<Book> Book { get; set; }
    }
}
