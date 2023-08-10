using System.Xml.Linq;

namespace BlogApp.Models;
public class Post : BaseEntity
{
    public Post()
    {
        Comments = new List<Comment>();
    }
    public int PostId { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public List<Comment> Comments { get; set; }
}
