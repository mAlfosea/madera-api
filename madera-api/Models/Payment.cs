using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IsPaid")]
        [Required]
        public bool IsPaid { get; set; }

        [Column("amount")]
        [Required]
        public float Amount { get; set; }

        public List<StepProject> StepProjects { get; set; }
    }
}
