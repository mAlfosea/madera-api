using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserDTO Client { get; set; }
    }
}
