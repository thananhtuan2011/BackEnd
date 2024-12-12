namespace BackEnd.Server.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
