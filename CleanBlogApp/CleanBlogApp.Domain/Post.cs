using System.Xml.Linq;
using CleanBlogApp.Domain.common;

namespace CleanBlogApp.Domain;
public class Post : BaseDomainEntity
{
    public Post()
    {
        Comments = new List<Comment>();
    }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public List<Comment> Comments { get; set; }
}
