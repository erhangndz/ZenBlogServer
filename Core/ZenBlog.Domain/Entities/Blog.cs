using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities;

    public class Blog: BaseEntity
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }


    }

