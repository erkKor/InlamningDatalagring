using InlamningDatalagring.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.Contexts
{
    internal class DataContext : DbContext
    {
        #region Constructors
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\46709\source\repos\InlamningDatalagring\InlamningDatalagring\Contexts\InlamningSqlDb.mdf;Integrated Security=True;Connect Timeout=30");
        }
        #endregion

        public DbSet<Errand> Errands { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<Comments> Comments { get; set; } = null!;

    }
}
