using System;
using System.Collections.Generic;

namespace ASPCoreApplication2023DBfirst.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Movies = new HashSet<Movie>();
            MoviesNavigation = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }

        public virtual ICollection<Movie> MoviesNavigation { get; set; }
    }
}
