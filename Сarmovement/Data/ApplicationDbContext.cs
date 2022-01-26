using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сarmovement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
    public class Car
    {
        public int CarId { get; set; }
        public string Number { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
    }
}
