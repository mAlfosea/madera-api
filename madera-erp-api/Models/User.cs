using madera_erp_api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_erp_api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IdErp { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Column("phone")]
        [MaxLength(100)]
        public string Phone { get; set; }

        [Column("role")]
        [Required]
        public RoleEnum Role { get; set; }

        [Column("civility")]
        [Required]
        public CivilityEnum Civility { get; set; }
    }
}
