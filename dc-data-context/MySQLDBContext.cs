using dc_datamodels.account;
using Microsoft.EntityFrameworkCore;
using System;

namespace dc_data_context
{
    public class MySQLDBContext : DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }

        public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserDataModel>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
            });
            builder.Entity<UserDataModel>().HasIndex(u => u.FullName);
        }
    }
}
