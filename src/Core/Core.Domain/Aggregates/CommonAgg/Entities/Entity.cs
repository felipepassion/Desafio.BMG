using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Events;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        DateTime? CreatedAt { get; set; }
    }

    public class Entity : IEntity
    {
        [NotMapped]
        private List<BaseEvent> _domainEvents;

        public Entity()
        {
            CreatedAt ??= DateTime.UtcNow;
            _externalId ??= Guid.NewGuid().ToString();
        }

        string _externalId;
        public string ExternalId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_externalId))
                {
                    CreatedAt ??= DateTime.UtcNow;
                    _externalId = Guid.NewGuid().ToString();
                }
                return _externalId;
            }
            set { this._externalId = value; }
        }

        [DisplayName("Criado em")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [DisplayName("Atualizado em")]
        public DateTime? UpdatedAt { get; set; }

        [DisplayName("Deletado em")]
        public DateTime? DeletedAt { get; set; }

        public virtual void Updated()
        {
            this.UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public bool Deletado { get; set; }

        [NotMapped]
        public List<BaseEvent> DomainEvents { get { return _domainEvents; } set { _domainEvents = _domainEvents ?? value; } }

        public void Delete()
        {
            this.Deletado = true;
            this.DeletedAt = DateTime.UtcNow;
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<BaseEvent>();
            _domainEvents.Add(domainEvent);
        }

        public bool IsEmpty()
        {
            return this.IsEmpty();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not IEntity) return false;

            return ((Entity)obj)?.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
