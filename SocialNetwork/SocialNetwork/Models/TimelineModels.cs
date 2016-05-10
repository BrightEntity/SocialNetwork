using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SocialNetwork.Models
{
    public class Timeline
    {
        [Key]
        public long TimelineID { get; set; }

        [InverseProperty("Timeline")]
        public virtual Profile Owner { get; set; }

        public virtual ICollection<IdentityUser> Followers { get; set; }
    }

    public class TimelinePost : IDatable
    {
        [Key]
        public long TimelinePostID { get; set; }

        public string AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual IdentityUser Author { get; set; }

        public long TimelineID { get; set; }
        [ForeignKey("TimelineID")]
        public virtual Timeline Timeline { get; set; }

        public string Content { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public event CreationEventHandler Created;
        public event ModificationEventHandler Modified;
    }
}
