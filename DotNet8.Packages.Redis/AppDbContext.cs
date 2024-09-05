using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Packages.Redis
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new()
            {
                DataSource = ".",
                InitialCatalog = "testDb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true
            };
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
