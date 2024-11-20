using FutureZawjehBlog.Models;
using Microsoft.AspNetCore.Identity;

namespace FutureZawjehBlog.Services
{
    public interface IPostService
    {
        Task<Post[]> GetPostsAsync();

        Task<bool> AddPostAsync(Post newPost, IdentityUser user);
    }
}
