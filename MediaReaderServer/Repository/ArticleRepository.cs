using MediaReaderServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaReaderServer.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private static List<ArticleModel> _inMemoryRepo = new List<ArticleModel>();

        public ArticleModel Create(ArticleModel articleModel)
        {
            articleModel.Id = new Random().Next();
            
            _inMemoryRepo.Add(articleModel);

            return articleModel;
        }

        public ArticleModel Get(int id)
        {
            return _inMemoryRepo.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ArticleModel> GetAll()
        {
            return _inMemoryRepo;
        }
    }

    public interface IArticleRepository
    {
        IEnumerable<ArticleModel> GetAll();

        ArticleModel Get(int id);

        ArticleModel Create(ArticleModel articleModel);
    }
}
