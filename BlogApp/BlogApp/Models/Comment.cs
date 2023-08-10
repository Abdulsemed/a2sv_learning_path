namespace BlogApp.Models;
public class Comment : BaseEntity
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; } = "";
    //public virtual Post Post { get; set; }
}

