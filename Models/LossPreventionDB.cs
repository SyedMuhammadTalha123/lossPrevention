using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loss_Prevention.Models
{
    public class LossPreventionDB : DbContext
    {
        public LossPreventionDB(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<Buy> Buys{ get; set; }
        public DbSet<Sell> Selldata { get; set; }
    }
}
