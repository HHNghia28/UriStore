using UriStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        public string PasswordHash { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedAt { get; set; } = DateTime.UtcNow;
    }

}
