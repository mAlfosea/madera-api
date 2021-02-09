using AutoMapper;
using madera_api.Data;
using madera_api.DTO;
using madera_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Services
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
                    LastName = "Lalane",
                    Email = "francis@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Roger",
                    LastName = "Moore",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.COMMERCIAL,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Michel",
                    LastName = "Palaref",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Jean Michel",
                    LastName = "Apeuprès",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Marcel",
                    LastName = "Patulacci",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Skippi",
                    LastName = "Legrandgourou",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                },
                new User
                {
                    FirstName = "Odile",
                    LastName = "De Ré",
                    Email = "roger@madera.fr",
                    Password = "1234",
                    Phone = "",
                    Role = Enums.RoleEnum.CLIENT,
                    Civility = Enums.CivilityEnum.MAN
                }
            };

            await _context.User.AddAsync(users[0]);
            await _context.User.AddAsync(users[1]);
            await _context.User.AddAsync(users[2]);
            await _context.User.AddAsync(users[3]);
            await _context.User.AddAsync(users[4]);
            await _context.User.AddAsync(users[5]);
            await _context.User.AddAsync(users[6]);

            foreach(User userDb in users)
            {            
                BrokerProducer.publishMessage(_mapper.Map<UserDTO>(userDb));
            }
            #endregion

            #region Seed Projects
            var projects = new[]
            {
                new Project
                {
                    Name = "Projet de maison de disque",
                    Client = users[0],
                    Commercial = users[1],
                },
                new Project
                {
                    Name = "Projet de la brigade du 3e arrondissement",
                    Client = users[4],
                    Commercial = users[1],
                }
            };

            await _context.Project.AddAsync(projects[0]);
            await _context.Project.AddAsync(projects[1]);

            var steps = new[]
            {
                new Step
                {
                    Label = "Phase de proposition",
                    Percent = 0
                },
                new Step
                {
                    Label = "Phase de proposition",
                    Percent = 0
                }
            };

            await _context.Step.AddAsync(steps[0]);
            await _context.Step.AddAsync(steps[1]);

            var payments = new[]
            {
                new Payment
                {
                    IsPaid = true,
                    Amount = 0
                },
                new Payment
                {
                    IsPaid = true,
                    Amount = 0
                }
            };

            await _context.Payment.AddAsync(payments[0]);
            await _context.Payment.AddAsync(payments[1]);

            var stepProjects = new[]
            {
                new StepProject
                {
                    Project = projects[0],
                    Payment = payments[0],
                    Step = steps[0]
                },
                new StepProject
                {
                    Project = projects[1],
                    Payment = payments[1],
                    Step = steps[1]
                }
            };

            await _context.StepProject.AddAsync(stepProjects[0]);
            await _context.StepProject.AddAsync(stepProjects[1]);
            #endregion

            #region Seed Collection / Module / Component
            var components = new[]
            {
                new Component
                {
                    Name = "Vis",
                    Nature = "Vis",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 349
                },
                new Component
                {
                    Name = "Boulon",
                    Nature = "Boulon",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 848
                },
                new Component
                {
                    Name = "Rondelle",
                    Nature = "Rondelle",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 128
                },
                new Component
                {
                    Name = "Clou",
                    Nature = "Clou",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 254
                }
            };

            await _context.Component.AddAsync(components[0]);
            await _context.Component.AddAsync(components[1]);
            await _context.Component.AddAsync(components[2]);
            await _context.Component.AddAsync(components[3]);

            var modules = new[]
            {
                new Module
                {
                    Name = "Toit en bois d'Ardoise",
                    Nature = "Toit",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0],
                        components[1],
                        components[2],
                        components[3]
                    }
                },
                new Module
                {
                    Name = "Mur en béton",
                    Nature = "Mur",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0],
                        components[1],
                        components[2]
                    }
                },
                new Module
                {
                    Name = "Colonne en bois",
                    Nature = "Mur",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0],
                        components[1]
                    }
                },
                new Module
                {
                    Name = "Mur en bois",
                    Nature = "Mur",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0],
                        components[1],
                        components[2]
                    }
                },
                new Module
                {
                    Name = "Toit en paille",
                    Nature = "Toit",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0],
                        components[1],
                        components[2],
                        components[3]
                    }
                }
            };

            var collections = new[]
            {
                new Collection
                {
                    Name = "Bois",
                    Modules = new []
                    {
                        modules[2],
                        modules[3],
                        modules[4]
                    }
                },
                new Collection
                {
                    Name = "Béton",
                    Modules = new []
                    {
                        modules[0],
                        modules[1]
                    }
                }
            };

            await _context.Collection.AddAsync(collections[0]);
            await _context.Collection.AddAsync(collections[1]);
            #endregion

            await _context.SaveChangesAsync(true);

            return true;
        }
    }
}
