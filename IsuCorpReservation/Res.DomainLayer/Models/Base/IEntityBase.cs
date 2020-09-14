namespace Res.DomainLayer.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
