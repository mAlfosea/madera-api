using madera_erp_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_erp_api.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string IdErp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public RoleEnum Role { get; set; }

        public CivilityEnum Civility { get; set; }
    }
}
