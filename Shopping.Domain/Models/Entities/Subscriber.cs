using Shopping.Infrastructure.Concrates;

namespace Shopping.Domain.Models.Entities
{
    public class Subscriber : AuditableEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
