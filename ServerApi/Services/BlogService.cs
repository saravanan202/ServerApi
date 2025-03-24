using System.Collections.Generic;
using ServerApi.Data;
using Microsoft.EntityFrameworkCore;
using ServerApi.Models;
using System.Linq; 
using System.Net;
using System.Text.Json;
namespace ServerApi.Services;

public class BlogService : IBlogService
{
    private readonly MyDbContext _dbContext;
    public BlogService(MyDbContext dbContext)
    {
        _dbContext = dbContext;

    }
    public  List<BlogPostVm> GetBlogs()
    {
             //Api();
        List<BlogPostVm>? blogs = _dbContext.BlogPost?
         .Select(s => new BlogPostVm
         {
             BlogId = s.BlogId,
             BlogContent = s.BlogContent. Replace("\r\n", "&#x000A;"),
             BlogTitle = s.BlogTitle,
             ImageId = s.ImageId,
             BlogContentOne = s.BlogContentOne. Replace("\r\n", "&#x000A;"),
             BlogContentTwo = s.BlogContentTwo. Replace("\r\n", "&#x000A;"),
             BlogContentThree = s.BlogContentThree. Replace("\r\n", "&#x000A;"),
             BlogContentFour = s.BlogContentFour. Replace("\r\n", "&#x000A;"),
             BlogContentFive = s.BlogContentFive. Replace("\r\n", "&#x000A;"),
             BlogContentSix = s.BlogContentSix. Replace("\r\n", "&#x000A;"),
             BlogContentSeven = s.BlogContentSeven,
             BlogContentEight = s.BlogContentEight,
             BlogContentNine = s.BlogContentNine,
             ImagePathOne = s.ImagePathOne,
             ImagePathTwo = s.ImagePathTwo,
             ImagePathThree = s.ImagePathThree,
             ImagePathFour = s.ImagePathFour,
             ImagePathFive = s.ImagePathFive,
             TitleImage = s.TitleImage,
             Conclusion = s.Conclusion,




         }).ToList();
        // Implement the logic to retrieve all blogs
        return blogs; // Assuming _dbContext is your data context and BlogPosts is the entity representing blog posts
    }
    /*   string QUERY_URL = ""
     Uri queryUri = new Uri(QUERY_URL);
*/
   /*  static async Task Api()
    {
        string queryUri = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=TCS&interval=5min&apikey=W3H64IOP8TL01HBC"; // Replace with your actual URI

        using (HttpClient client = new HttpClient())
        {
            string json_data = await client.GetStringAsync(queryUri);

            // Deserialize JSON using System.Text.Json
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Optional: To make property names case-insensitive
            };

            var result = JsonSerializer.Deserialize<object>(json_data, options);

            // Use 'result' for further processing
            Console.WriteLine(result);
        }
    } */
    public bool InsertSubscribe(Subscriber subscriberData)
    {
        Subscriber? sups = _dbContext.Subscriber?.SingleOrDefault(w => w.Email == subscriberData.Email) ?? new Subscriber();

        if (sups.Email == null)
        {
            sups = new()
            {
                Email = subscriberData.Email
            };
            _dbContext.Add(sups);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}