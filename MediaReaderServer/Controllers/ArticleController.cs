using MediaReaderServer.Models;
using MediaReaderServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediaReaderServer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult ListAll()
        {
            return Ok(_articleService.GetAll());
        }

        public IActionResult Get(int id)
        {
            return Ok(_articleService.GetById(id));
        }

        public IActionResult Submit(ArticleModel articleModel)
        {
            var created = _articleService.Create(articleModel);
            
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
    }
}
