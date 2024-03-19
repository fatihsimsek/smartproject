using System;
namespace SmartProject.Domain.Common
{
	public abstract class AggregateRoot : Entity
	{
		private readonly ICollection<DomainEvent> events;

		protected AggregateRoot()
		{
			events = new List<DomainEvent>();
		}

		public IReadOnlyCollection<DomainEvent> Events => this.events.ToList().AsReadOnly();

		public void ClearEvents() => this.events.Clear();

		protected void RaiseEvent(DomainEvent domainEvent) => this.events.Add(domainEvent);
	}
}

