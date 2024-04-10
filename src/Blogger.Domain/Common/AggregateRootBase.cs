﻿namespace Blogger.Domain.Common;
public abstract class AggregateRootBase<TId> : EntityBase<TId> , IAggregateRoot
    where TId : notnull
{
    public IReadOnlyCollection<IDomainEvent> Events => _events.ToImmutableArray();

    private readonly IList<IDomainEvent> _events;

    protected AggregateRootBase(TId id) : base(id)
    {
        _events = new List<IDomainEvent>();
    }

    public void ClearEvents() => _events.Clear();

    protected void AddEvent<TDomainEvent>(TDomainEvent @event) 
        where TDomainEvent : IDomainEvent => _events.Add(@event);
}
