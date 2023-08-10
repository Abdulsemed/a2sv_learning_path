using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private static AppDbContext _context;
    public PostController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var posts = await _context.Posts.ToListAsync();
            foreach (var post in posts)
            {
                var comment = await _context.Comments.Where(c => c.PostId == post.PostId).ToListAsync();
                post.Comments = comment;
            }

            return Ok(posts);
        } catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == id);
            var comments = await _context.Comments.Where(p => p.PostId == id).ToListAsync();
            if (post == null)
            {
                return BadRequest("invalid id");
            }
            post.Comments = comments;
            return Ok(post);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        try
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", post.PostId, post);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, string title, string content) 
    {
        try
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return BadRequest("invalid id");
            }
            post.Title = title;
            post.Content = content;
            await _context.SaveChangesAsync();
            return NoContent();
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (post == null)
            {
                return BadRequest("invalid id");
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

