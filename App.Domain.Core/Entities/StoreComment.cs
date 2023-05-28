namespace App.Domain.Core.Entities;

public partial class StoreComment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? CommentBody { get; set; }

    public int UserId { get; set; }

    public int StoreId { get; set; }

    public bool IsConfirmedByAdmin { get; set; }

    public int? ParentCommentId { get; set; }

    public int? Rate { get; set; }

    public int? LikeCount { get; set; }

    public int? DislikeCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Store Store { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
