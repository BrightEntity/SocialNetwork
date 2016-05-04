using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SocialNetwork.Models
{
    public abstract class Commentable : ICommentable
    {
        [Key]
        public long CommentableID { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }

    }

    public static class CommentableExtensions
    {
        public static ICollection<Comment> GetComments(this ICommentable commentable)
        {
            return commentable.Comments;
        }
    }

    public interface ICommentable
    {
        [Key]
        long CommentableID { get; set; }

        ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        [Key]
        public long CommentID { get; set; }

        public string ChildCommentID { get; set; }
        [ForeignKey("ChildCommentID")]
        public virtual ICollection<Comment> ChildComments { get; set; }

        public virtual IdentityUser Author { get; set; }
        public string Content { get; set; }
        
        public virtual ICollection<Reaction> Reactions { get; set; }

    }

}