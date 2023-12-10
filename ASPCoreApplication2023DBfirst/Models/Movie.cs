using System;
using System.Collections.Generic;

namespace ASPCoreApplication2023DBfirst.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public Guid? GenreId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Genre? Genre { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
