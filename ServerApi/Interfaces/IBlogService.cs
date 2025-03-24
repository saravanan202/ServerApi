using ServerApi.Models;

namespace ServerApi.Services
{
    public interface IBlogService
    {
        List<BlogPostVm> GetBlogs();
        bool InsertSubscribe(Subscriber subscriberData); 
    }
}
