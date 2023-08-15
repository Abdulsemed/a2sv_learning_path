using CleanBlogApp.Domain.common;

namespace CleanBlogApp.Domain;
public class Comment : BaseDomainEntity
{
    public int CommentId { get; set; }
    public string Text { get; set; } = "";
}

