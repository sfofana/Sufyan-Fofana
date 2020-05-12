using JS.Fofana_Bank_V2._3_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Fofana_Bank_V2._3_Backend.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     id = 1,
                     firstname = "Amir",
                     lastname = "Kamara",
                     email = "master@gmail.com",
                     password = "demo"
                 },
                 new User
                 {
                     id = 2,
                     firstname = "System",
                     lastname = "Admin",
                     email = "system@gmail.com",
                     password = "admin"
                 }
                 );
            modelBuilder.Entity<Account>().HasData(
                 new Account
                 {
                     id = 1001,
                     name = "checking",
                     amount = 16654.12,
                     user = 1
                 },
                new Account
                {
                    id = 1002,
                    name = "saving",
                    amount = 67852.12,
                    user = 1
                },
                new Account
                {
                    id = 1003,
                    name = "checking",
                    amount = 3537.25,
                    user = 1
                },
                new Account
                {
                    id = 1004,
                    name = "saving",
                    amount = 7165.12,
                    user = 1
                },
                new Account
                {
                    id = 1005,
                    name = "checking",
                    amount = 101010.01,
                    user = 2
                },
                new Account
                {
                    id = 1006,
                    name = "saving",
                    amount = 1111.10,
                    user = 2
                }
                 );

        }
    }
}
