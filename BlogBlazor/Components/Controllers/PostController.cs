using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogBlazor.Data;
using BlogBlazor.Models;

namespace BlogBlazor.Controllers;

[Route("posts")]
[ApiController]
public class PostController : Controller
{
    private readonly BlogBlazorDbContext _db;

    public PostController(BlogBlazorDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPosts()
    {
        return (await _db.Posts.ToListAsync()).ToList();
    }

    [HttpPost]
    public void AddPost(string title, string content)
    {
        _db.Posts.Add(new Post { Title = title, Content = content });
        _db.SaveChanges();
    }
}