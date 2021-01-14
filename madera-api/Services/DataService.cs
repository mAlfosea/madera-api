using AutoMapper;
using madera_api.Data;
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

            #region Seed Projects
            var projects = new[]
            {
                new Project
                {
                    Name = "Projet de Francis",
                    Client = users[0],
                    Commercial = users[1],
                }
            };

            await _context.Project.AddAsync(projects[0]);

            var steps = new[]
            {
                new Step
                {
                    Label = "Phase de proposition",
                    Percent = 0
                }
            };

            await _context.Step.AddAsync(steps[0]);

            var payments = new[]
            {
                new Payment
                {
                    IsPaid = true,
                    Amount = 0
                }
            };

            await _context.Payment.AddAsync(payments[0]);

            var stepProjects = new[]
            {
                new StepProject
                {
                    Project = projects[0],
                    Payment = payments[0],
                    Step = steps[0]
                }
            };

            await _context.StepProject.AddAsync(stepProjects[0]);
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
                    Price = 15
                },
                new Component
                {
                    Name = "Boulon",
                    Nature = "Boulon",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 8
                }
            };

            await _context.Component.AddAsync(components[0]);
            await _context.Component.AddAsync(components[1]);

            var modules = new[]
            {
                new Module
                {
                    Name = "Toit en bois d'Erable",
                    Nature = "Toit",
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
                    Name = "Mur en bois d'Erable",
                    Nature = "Mur",
                    Trait = "Bois",
                    Unite = "M²",
                    Components = new []
                    {
                        components[0]
                    }
                }
            };

            var collections = new[]
            {
                new Collection
                {
                    Name = "Printemps",
                    Modules = new []
                    {
                        modules[0],
                        modules[1]
                    }
                },
                new Collection
                {
                    Name = "Eté"
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
