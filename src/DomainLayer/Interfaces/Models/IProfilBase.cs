namespace DomainLayer.Interfaces.Models
{
    class IProfilBase
    {
        Guid Id { get; }
        string Name { get; set; } = string.Empty;
    }
}
