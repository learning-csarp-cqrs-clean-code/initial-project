namespace DomainLayer.Interfaces.Models
{
    class IProfileBase
    {
        Guid Id { get; }
        string Name { get; set; } = string.Empty;
    }
}
