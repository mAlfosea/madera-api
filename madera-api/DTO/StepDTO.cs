using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public int Percent { get; set; }

        public List<StepProjectDTO> StepProjects { get; set; }
    }
}
