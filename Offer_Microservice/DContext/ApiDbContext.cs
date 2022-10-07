using Microsoft.EntityFrameworkCore;
using Offer_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offer_Microservice.DContext
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Offer_Category> Offer_Categories  { get; set; }
        public DbSet<Employee_Offers> Employee_Offers { get; set; }
    }
}
