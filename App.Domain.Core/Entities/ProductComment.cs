using App.Domain.Core.Entities;

namespace MarketPlace.Entities;

public partial class ProductComment
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? CommentBody { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public bool IsConfirmedByAdmin { get; set; }

    public int? ParentCommentId { get; set; }

    public int? Rate { get; set; }

    public int? LikeCount { get; set; }

    public int? DislikeCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ApplicationUser User { get; set; } = null!;
}
