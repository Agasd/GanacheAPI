using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GanacheAPI.Models
{
    public class GanacheAPIContext : DbContext
    {
        public GanacheAPIContext (DbContextOptions<GanacheAPIContext> options)
            : base(options)
        {
        }

        public DbSet<GanacheAPI.Models.User> Users { get; set; }
    }
}
