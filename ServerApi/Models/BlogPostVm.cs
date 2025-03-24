namespace ServerApi.Models
{
    public class BlogPostVm
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogContent { get; set; }
        public int? ImageId { get; set; }
        public string? BlogContentOne { get; set; }
        public string? BlogContentTwo { get; set; }
        public string? BlogContentThree { get; set; }
        public string? BlogContentFour { get; set; }
        public string? BlogContentFive { get; set; }
        public string? BlogContentSix { get; set; }
        public string? BlogContentSeven { get; set; }
        public string? BlogContentEight { get; set; }
        public string? BlogContentNine { get; set; }
        public string? ImagePathOne { get; set; }
        public string? ImagePathTwo { get; set; }
        public string? ImagePathThree { get; set; }
        public string? ImagePathFour { get; set; }
        public string? ImagePathFive { get; set; }
        public string? TitleImage { get; set; }
        public string? Conclusion {get;set;}

    }
    public class Subscriber
    {
        public string? Email { get; set; }
        public bool SubscriberExist { get; set; }
    }

}
