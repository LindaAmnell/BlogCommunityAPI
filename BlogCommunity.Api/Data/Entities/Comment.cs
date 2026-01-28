using System.ComponentModel.DataAnnotations;

namespace BlogCommunity.Api.Data.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string Text { get; set; }

        public int UserID { get; set; }
        public int PostID { get; set; }

    }
}
