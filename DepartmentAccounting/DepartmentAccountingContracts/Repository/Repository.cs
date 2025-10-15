using DepartmentAccountingContracts.Models;

namespace DepartmentAccountingContracts.Repository;

public class Repository<TEntity> where TEntity : Entity
{
    public Action? DataChanged { get; set; }
    private readonly Dictionary<Guid, TEntity> _entities = [];

    public TEntity? GetById(Guid id) => _entities.TryGetValue(id, out TEntity? entity) switch
    {
        true => entity,
        false => null
    };

    public IEnumerable<TEntity> GetAll() => _entities.Values;

    public void Add(TEntity entity)
    {
        _entities.Add(entity.Id, entity);
        DataChanged?.Invoke();
    }

    public void Update(TEntity entity)
    {
        if (_entities.ContainsKey(entity.Id))
            _entities[entity.Id] = entity;
        DataChanged?.Invoke();
    }

    public void Delete(Guid id)
    {
        _entities.Remove(id);
        DataChanged?.Invoke();
    }

    public void Delete(IEnumerable<Guid> ids)
    {
        foreach (var id in ids)
            Delete(id);
    }
}
