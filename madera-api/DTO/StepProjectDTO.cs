using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class StepProjectDTO
    {
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }

        public int StepId { get; set; }
        public StepDTO Step { get; set; }

        public int PaymentId { get; set; }
        public PaymentDTO Payment { get; set; }
    }
}
