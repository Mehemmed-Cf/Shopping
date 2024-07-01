
namespace Shopping.Application.Modules.ContactPostsModule.Queries
{
    public class ContactPostRequestDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public DateTime? AnsweredAt { get; set; }
        public int? AnsweredBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
