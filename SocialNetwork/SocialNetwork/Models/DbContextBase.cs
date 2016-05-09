using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public abstract class DbContextBase : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entities = new List<DbSet>();
            foreach (var item in this.Entry()
            {
                entities.Add(item.GetProperties().Where(e => e.GetType() == typeof(DbSet)).);
            }
                
            modelBuilder.Entity<object>().ha

            base.OnModelCreating(modelBuilder);
        }
    }
}