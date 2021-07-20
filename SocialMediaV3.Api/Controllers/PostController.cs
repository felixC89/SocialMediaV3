using Microsoft.AspNetCore.Mvc;
using SocialMediaV3.InfraStructure.Repositories;

namespace SocialMediaV3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPosts() 
        {
            var post = new PostRepository().GetPosts();
            return Ok(post);
        }

    }
}
