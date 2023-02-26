﻿
namespace Library.Domain.Entities
{
    internal class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}