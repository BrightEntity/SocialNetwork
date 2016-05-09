using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    class CommentDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ReactionType> ReactionTypes { get; set; }

        

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.State != EntityState.Unchanged)
                {
                    try
                    {
                        item.CurrentValues.SetValues(new { ModifiedAt = DateTime.Now });
                    }
                    catch (Exception)
                    {
                        // Fails silently
                    }
                }
            }

            

            return base.SaveChanges();
        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder); 
        }
    }
}
