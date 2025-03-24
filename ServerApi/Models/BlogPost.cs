using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("blogpost")]
public class BlogPost
{
    [Key]
    [Column("blog_id")]
    public int BlogId { get; set; }
    [Column("blog_title")]
    public string? BlogTitle { get; set; }
    [Column("blog_content")]
    public string? BlogContent { get; set; }
    [Column("image_id")]
    public int? ImageId { get; set; }

    [Column("blog_content_one")]
    public string? BlogContentOne { get; set; }

    [Column("blog_content_two")]
    public string? BlogContentTwo { get; set; }

    [Column("blog_content_three")]
    public string? BlogContentThree { get; set; }

    [Column("blog_content_four")]
    public string? BlogContentFour { get; set; }

    [Column("blog_content_five")]
    public string? BlogContentFive { get; set; }

    [Column("blog_content_six")]
    public string? BlogContentSix { get; set; }

    [Column("blog_content_seven")]
    public string? BlogContentSeven { get; set; }

    [Column("blog_content_eight")]
    public string? BlogContentEight { get; set; }

    [Column("blog_content_nine")]
    public string? BlogContentNine { get; set; }
    [Column("image_path_one")]
    public string? ImagePathOne { get; set; }
    [Column("image_path_two")]
    public string? ImagePathTwo { get; set; }
    [Column("image_path_three")]
    public string? ImagePathThree { get; set; }
    [Column("image_path_four")]
    public string? ImagePathFour { get; set; }
    [Column("image_path_five")]
    public string? ImagePathFive { get; set; }
    [Column("title_image")]
    public string? TitleImage { get; set; }
    [Column("conclusion")]
    public string? Conclusion { get; set; }
}

