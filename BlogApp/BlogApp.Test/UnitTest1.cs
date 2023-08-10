namespace BlogApp.Test;

using BlogApp.Controllers;
using BlogApp.Data;
using BlogApp.Models;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;

public class PostControllerTests
{
    private readonly AppDbContext _context;
    public PostControllerTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

        _context = new AppDbContext(optionsBuilder.Options);
    }
    [Fact]
    public async Task GetPosts()
    {
        //Arrange
        
        var controller = new PostController(_context);
        //Act
        var result = await controller.Get();

        //Assert
        Assert.IsType<OkObjectResult>(result);
        
    }

    [Fact]
    public async Task GetPostById()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        _context.Posts.Add(new Post
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        });
        await _context.SaveChangesAsync();

        //Act
        var result =await controller.Get(id);

        //Assert
        Assert.IsType<OkObjectResult>(result);

    }
    [Fact]
    public async Task PostNewPost()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        Post post = new Post()
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        };

        //Act
        var result  = await controller.Post(post);

        //Assert
        Assert.IsType<CreatedAtActionResult>(result);

    }
    [Fact]
    public async Task PathchApost()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        _context.Posts.Add(new Post
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        });

        await _context.SaveChangesAsync();
        string Title = "patch";
        var content = "Patched Content";

        //Act
        var result = await controller.Patch(id,Title,content);

        //Assert
        Assert.IsType<NoContentResult>(result);
    }
    [Fact]
    public async Task BadRequestForApost()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        Post post = new Post()
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        };
        _context.Posts.Add(new Post
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        });
        await _context.SaveChangesAsync();
        //Act
        var result = await controller.Post(post);

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task DeleteAPost()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        _context.Posts.Add(new Post
        {
            PostId = id,
            Title = "Test",
            Content = "Test"
        });

        await _context.SaveChangesAsync();

        //Act
        var result = await controller.Delete(id);

        //Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task BadRequestForDeleteAPost()
    {
        //Arrange
        var controller = new PostController(_context);
        var id = 1;
        
        //Act
        var result = await controller.Delete(id);

        //Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
