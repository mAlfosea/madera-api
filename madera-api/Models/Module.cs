using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class Module
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

        public virtual ICollection<Collection> Collections { get; set; }

        public virtual ICollection<Component> Components { get; set; }

        public List<ProposalModule> ProposalModules { get; set; }
    }
}
