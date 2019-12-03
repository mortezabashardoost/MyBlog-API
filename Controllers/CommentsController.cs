using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogApi.Data;
using MyBlogApi.Models;

namespace MyBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public CommentsController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet("GetTopPosts/{count}")]
        public ActionResult<IEnumerable<Comment>> GetTopPosts(int count)
        {
            var topPosts = _context.Comments
                .GroupBy(c => c.PostId)
                .Select(p=>new {
                    PostId = p.Key ,
                    TotalComments = p.Count()
            }).OrderByDescending(p => p.TotalComments).ToList().Take(count);

            return Ok(topPosts);
        }

    }
}
