using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private static AppDbContext _context;
    public CommentController(AppDbContext appDbContext)
    {
        _context = appDbContext;

    }
    // here implement to get all comments of a post with post id
    [HttpGet("{postId:int}")]
    public async Task<IActionResult> Get(int postId)
    {
        try
        {
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == postId);
            if (post == null)
            {
                return BadRequest("invalid pid");
            }
            var comments = await _context.Comments.Where(p => p.PostId == postId).ToListAsync();
            return Ok(comments);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{postId:int},{commentId:int}")]
    public async Task<IActionResult> Get(int postId, int commentId)
    {
        try
        {
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == postId);
            if (post == null)
            {
                return BadRequest("invalid pid");
            }
            var comment = await _context.Comments.SingleOrDefaultAsync(c => c.PostId == postId && c.CommentId == commentId);
            if (comment == null)
            {
                return BadRequest("comment not found");
            }
            return Ok(comment);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Comment comment)
    {
        try
        {

            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == comment.PostId);
            if (post == null)
            {
                return BadRequest("invalid post id");
            }
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return Ok(comment);
            //return CreatedAtAction("Get", new { comment.PostId, comment.CommentId }, comment);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int postId, int commentId, string text)
    {
        try
        {
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == postId);
            if (post == null)
            {
                return BadRequest("invalid post id");
            }

            var comment = await _context.Comments.SingleOrDefaultAsync(c => c.PostId == postId && c.CommentId == commentId);
            if (comment == null)
            {
                return BadRequest("comment not found");
            }
            comment.Text = text;
            await _context.SaveChangesAsync();
            return NoContent();
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int postId, int commentId)
    {
        try
        {
            // check if comment exist in a post using post id
            var post = await _context.Posts.SingleOrDefaultAsync(p => p.PostId == postId);
            if (post == null)
            {
                return BadRequest("invalid post id");
            }

            var comment = await _context.Comments.SingleOrDefaultAsync(c => c.PostId == postId && c.CommentId == commentId);
            if (comment == null)
            {
                return BadRequest("comment not found");
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

