using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRest.Entities;

namespace WebApiRest.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {
                
        }
        public DbSet<Contacto> contacto { get; set; }
    }
}
