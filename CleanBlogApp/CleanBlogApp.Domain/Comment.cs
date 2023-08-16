using CleanBlogApp.Domain.common;

namespace CleanBlogApp.Domain;
public class Comment : BaseDomainEntity
{
    public int PostId { get; set; }
    public string Text { get; set; } = "";
}

