namespace BlogCommunity.Api.Dtos.postDto
{
    public class UpdatePostDto
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int? CategoryID { get; set; }
    }
}
