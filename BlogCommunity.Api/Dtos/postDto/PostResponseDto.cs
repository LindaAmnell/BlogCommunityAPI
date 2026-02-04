namespace BlogCommunity.Api.Dtos.postDto
{
    public class PostResponseDto
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
    }

}
