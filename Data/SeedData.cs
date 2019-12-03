using MyBlogApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlogApi.Data
{
    public static class SeedData
    {

        public static void Process(BlogDbContext context)
        {
            var commentsJsonString = File.ReadAllText("Data/comments.json");
            CommentsFile commentsFile = JsonConvert.DeserializeObject<CommentsFile>(commentsJsonString);

            context.Comments.AddRange(commentsFile.Comments);
            context.SaveChanges();

        }

    }

    public class CommentsFile
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
