using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SocialNetwork.Models
{
    public class Comment
    {
        [Key]
        public long CommentID { get; set; }

        public string ParentID { get; set; }
        public string ParentType { get; set; }
        [ForeignKey("ParentID")]
        public virtual object Parent { get; set; }

        public virtual IdentityUser Author { get; set; }
        public string Content { get; set; }


        public virtual ICollection<Reaction> Reactions { get; set; }

    }

    public class Reaction
    {
        public long ReactionID { get; set; }

        public virtual ReactionType ReactionType { get; set; }
    }

    public class ReactionType : IDatable
    {
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
        public IdentityUser Author { get; set; }

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