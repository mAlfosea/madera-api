using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("label")]
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }

        [Column("percent")]
        [Required]
        public int Percent { get; set; }

        public List<StepProject> StepProjects { get; set; }
    }
}
