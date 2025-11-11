using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bmg.Desafio.Users.Identity
{
    [Table("aspnetusers")]
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
        public ApplicationUser()
        {
            this.ExternalId = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.UtcNow;
        }

        public string Name { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
        
        public string ExternalId { get; set; }

        public bool IsDeleted { get; set; }

        public string GetTitle()
        {
            return string.Empty;
        }

        public string GetTitlePropName()
        {
            return string.Empty;
        }
    }
}
