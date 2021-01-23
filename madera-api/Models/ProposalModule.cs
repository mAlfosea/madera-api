using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class ProposalModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; } = null;

        public int Quantity { get; set; }
    }
}
