using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureData.Models;

namespace SecureData.Data
{
    public class SecureDataContext : DbContext
    {
        public SecureDataContext (DbContextOptions<SecureDataContext> options)
            : base(options)
        {
        }

        public DbSet<SecureData.Models.Order> Orders { get; set; }
    }
}
