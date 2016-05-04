using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{

    public class Reaction
    {
        [Key]
        public long ReactionID { get; set; }

        public virtual ReactionType ReactionType { get; set; }
        public string AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual IdentityUser Author { get; set; }
    }

    public class ReactionType : IDatable
    {
        [Key]
        public long ReactionTypeID { get; set; }

        public ReactionType()
        {
            Created += ReactionType_Created;
            Modified += ReactionType_Modified;
        }

        private void ReactionType_Modified(object sender, ModificationEventArgs e)
        {
            ModifiedAt = DateTime.Now;
        }

        private void ReactionType_Created(object sender, CreationEventArgs e)
        {
            CreatedAt = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public event CreationEventHandler Created;
        public event ModificationEventHandler Modified;

        public void OnCreated(CreationEventArgs e)
        {
            CreationEventHandler temp = Created;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void OnModified(ModificationEventArgs e)
        {
            ModificationEventHandler temp = Modified;
            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
}
