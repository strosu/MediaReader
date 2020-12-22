using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaReaderServer.Models
{
    public class ArticleModel
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string HtmlBody { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }

        public IEnumerable<string> TestLinks { get; set; }
    }

    public class LinkModel
    {
        public string Url { get; set; }
    }
}
