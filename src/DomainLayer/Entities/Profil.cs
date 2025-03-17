using DomainLayer.Commons;

namespace DomainLayer.Entities
{
    public class Profil : Entity
    {
        public Profil(Guid id) : base(id)
        {
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
