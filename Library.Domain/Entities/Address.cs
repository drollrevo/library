﻿
using System;

namespace Library.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Build { get; set; }
        public List<Client> Client { get; set; } = new List<Client>();
    }
}
