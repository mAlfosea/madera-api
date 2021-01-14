using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Models
{
    public class StepProject
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int StepId { get; set; }
        public Step Step { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
