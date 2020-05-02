namespace WebStore.DomainNew.Entities.Base.Interfaces
{
    public interface INamedEntity : IBaseEntity
    {
        new int Id { get; set; }
        string Name { get; set; }
    }
}