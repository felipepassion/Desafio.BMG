using Bmg.Desafio.Core.Domain.Aggregates.CommonAgg.Entities;
using Bmg.Desafio.Users.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Entities
{
    public class User : Entity
    {
        public User()
        {
        }

        [Required]
        public string Name { get; set; }

        public UserRole UserRole { get; set; }

        public bool NeedSendOnboardingMail { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, NotMapped]
        public string Password { get; set; }

        [NotMapped, JsonIgnore]
        public string AuthToken { get; set; }
    }
}
