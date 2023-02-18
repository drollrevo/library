
namespace Library.Domain.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
