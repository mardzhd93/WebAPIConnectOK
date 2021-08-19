using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIConnectOK.Models;

namespace WebAPIConnectOK.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {
        }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }
		
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IROXIT031\\SQLEXPRESS;Initial Catalog=ForTech;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
