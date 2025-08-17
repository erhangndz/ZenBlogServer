using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities
{
    public class Comment: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }


    }
}
