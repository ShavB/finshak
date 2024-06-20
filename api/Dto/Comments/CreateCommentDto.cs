namespace api.Dto.Comments
{
    public class CreateCommentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
    }
}