using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public abstract class Timelinable
    {
        [Key]
        public long Id { get; set; }

        public virtual string DisplayName { get; }
    }

    public class SocialProfile : Timelinable
    {
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser User { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string DisplayName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }

    public class PageProfile : Timelinable
    {
        public string Name { get; set; }

        public override string DisplayName
        {
            get
            {
                return Name;
            }
        }
    }
}

