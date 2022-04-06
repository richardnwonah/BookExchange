using System.Collections.Generic;

namespace BookExchange.Core.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Book>? Book { get; set; }
    }
}