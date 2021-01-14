using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public bool IsPaid { get; set; }

        public float Amount { get; set; }

        public List<StepProjectDTO> StepProjects { get; set; }
    }
}
