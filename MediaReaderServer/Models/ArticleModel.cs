using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaReaderServer.Models
{
    public class ArticleModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string HtmlBody { get; set; }
    }
}
