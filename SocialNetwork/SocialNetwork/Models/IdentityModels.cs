using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    

    public class ApplicationUser : IdentityUser
    {
        public long SocialProfileID { get; set; }
        [ForeignKey("SocialProfileID")]
        public virtual SocialProfile SocialProfile { get; set; }

        public ApplicationUser()
        {
            SocialProfile = new SocialProfile();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasRequired<Timeline>(e => e.Timeline).WithRequiredPrincipal(e => e.Owner).Map(e => e.MapKey("TimelineID"));
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Profile> Profiles { get; set; }


        //public System.Data.Entity.DbSet<SocialNetwork.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}