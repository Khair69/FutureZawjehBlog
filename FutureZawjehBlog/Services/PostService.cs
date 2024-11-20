using FutureZawjehBlog.Data;
using FutureZawjehBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FutureZawjehBlog.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPostAsync(Post newPost, IdentityUser user)
        {
            newPost.Id = Guid.NewGuid();
            newPost.TimeOfPost = DateTimeOffset.Now;
            newPost.UserId = user.Id;

            _context.posts.Add(newPost);

            var saveRes = await _context.SaveChangesAsync();
            return saveRes == 1;
        }

        public async Task<Post[]> GetPostsAsync()
        {
            return await _context.posts.ToArrayAsync();
        }
    }
}
