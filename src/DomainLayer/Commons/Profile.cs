

namespace DomainLayer.Commons
{
    public class Profile : Entity
    {
        public Profile(Guid id) : base(id) {}
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
