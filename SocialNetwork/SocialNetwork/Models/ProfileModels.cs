using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public abstract class Profile
    {
        [Key]
        public long Id { get; set; }

        public virtual string Display { get; }

        public long TimelineID { get; set; }
        [ForeignKey("TimelineID")]
        public Timeline Timeline { get; set; }

        public Profile()
        {
            if (Timeline == null)
            {
                Timeline = new Timeline();
            }
            
        }
        
    }

    public class SocialProfile : Profile
    {
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual IdentityUser User { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string Display
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }

    public class PageProfile : Profile
    {
        public string Name { get; set; }

        public PageProfile()
        {
            Owners = new HashSet<IdentityUser>();
        }
        
        public virtual ICollection<IdentityUser> Owners { get; set; }

        public override string Display
        {
            get
            {
                return Name;
            }
        }
    }
}

