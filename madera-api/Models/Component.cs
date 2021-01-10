using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("nature")]
        [Required]
        [MaxLength(100)]
        public string Nature { get; set; }

        [Column("trait")]
        [Required]
        [MaxLength(100)]
        public string Trait { get; set; }

        [Column("unite")]
        [Required]
        [MaxLength(100)]
        public string Unite { get; set; }

        [Column("price")]
        [Required]
        [MaxLength(100)]
        public double Price { get; set; }

        [Column("module")]
        public ICollection<Module> Modules { get; set; }
    }
}
