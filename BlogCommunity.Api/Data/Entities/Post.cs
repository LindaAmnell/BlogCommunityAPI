
using System.ComponentModel.DataAnnotations;

namespace BlogCommunity.Api.Data.Entities
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int UserID { get; set; }
        public int CategoryID { get; set; }
    }
}
