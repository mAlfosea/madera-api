using AutoMapper;
using madera_erp_api.Data;
using madera_erp_api.Models;
using System.Threading.Tasks;

namespace madera_erp_api.Services
{
    public class DataService : IDataService
    {
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public DataService(DbMainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateData()
        {
            #region Seed Users
            var users = new[]
            {
                new User
                {
                    FirstName = "Francis",
                    LastName = "Client",
                    Email = "francis@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Roger",
                    LastName = "Commercial",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.COMMERCIAL,
                    Civility = Enums.CivilityEnum.MAN
                }
            };

            await _context.User.AddAsync(users[0]);
            await _context.User.AddAsync(users[1]);
            #endregion

            await _context.SaveChangesAsync(true);

            return true;
        }
    }
}
