using MediaReaderServer.Models;
using MediaReaderServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaReaderServer.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
        //[HttpGet("")]
        [Route("")]
        public IActionResult ListAll()
        {
            return Ok(_articleService.GetAll());
        }

        //[HttpGet("Get/{id}")]
        [Route("Get/{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            return Ok(_articleService.GetById(id));
        }

        [HttpPost("Submit")]
        public IActionResult Submit([FromForm]ArticleModel articleModel)
        {
            var created = _articleService.Create(articleModel);
            
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
    }
}
