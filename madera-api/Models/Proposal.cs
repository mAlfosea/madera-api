using madera_api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class Proposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int CommercialId { get; set; }

        public User Commercial { get; set; }

        public int CollectionId { get; set; }

        [Column("creation-date")]
        [Timestamp]
        public byte[] CreationDate { get; set; }

        [Column("status")]
        public ProposalEnum Status { get; set; }

        public List<ProposalModule> ProposalModules { get; set; }
    }
}
