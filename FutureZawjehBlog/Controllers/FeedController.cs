using FutureZawjehBlog.Models;
using FutureZawjehBlog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FutureZawjehBlog.Controllers
{
    public class FeedController : Controller
    {
        private readonly IPostService _postService;

        private readonly UserManager<IdentityUser> _userManager;

        public FeedController(IPostService postService, UserManager<IdentityUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPostsAsync();

            var model = new PostsViewModel { Posts = posts };

            return View(model);
        }

        [Authorize]
        public IActionResult AddPostForm()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(Post newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("modelmodel");
            }
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) { return Challenge(); }


            var successful = await _postService.AddPostAsync(newPost, currentUser);

            if (!successful)
            {
                return BadRequest("Couldn't add item");
            }

            return RedirectToAction("Index");

        }
    }
}
