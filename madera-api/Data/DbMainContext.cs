using madera_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace madera_api.Data
{
    public class DbMainContext: DbContext
    {
        public DbMainContext(DbContextOptions<DbMainContext> opt): base(opt)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Component> Component { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = new[]
            {
                new User
                    {
                        Id = 1,
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
                        Id = 2,
                        FirstName = "Roger",
                        LastName = "Commercial",
                        Email = "roger@madera.fr",
                        Password = "1234",
                        Phone = "",
                        Role = Enums.RoleEnum.COMMERCIAL,
                        Civility = Enums.CivilityEnum.MAN
                    }
            };

            var modules = new[]
            {
                new Module
                {
                    Id = 1,
                    Name = "Toit en bois d'Erable",
                    Nature = "Toit",
                    Trait = "Bois",
                    Unite = "M²"
                },
                new Module
                {
                    Id = 2,
                    Name = "Mur en bois d'Erable",
                    Nature = "Mur",
                    Trait = "Bois",
                    Unite = "M²"
                }
            };

            var collections = new[]
            {
                new Collection
                {
                    Id = 1,
                    Name = "Printemps"
                },
                new Collection
                {
                    Id = 2,
                    Name = "Eté"
                }
            };

            var components = new[]
            {
                new Component
                {
                    Id = 1,
                    Name = "Vis",
                    Nature = "Vis",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 15
                },
                new Component
                {
                    Id = 2,
                    Name = "Boulon",
                    Nature = "Boulon",
                    Trait = "Fer",
                    Unite = "Kg",
                    Price = 8
                }
            };


            modelBuilder.Entity<Collection>()
                .HasMany<Module>(s => s.Modules)
                .WithMany(c => c.Collections)
                .UsingEntity(j => j.HasData(
                    new { CollectionsId = 1, ModulesId = 1 },
                    new { CollectionsId = 1, ModulesId = 2 }
                    ));

            modelBuilder.Entity<Module>()
                .HasMany<Component>(s => s.Components)
                .WithMany(c => c.Modules)
                .UsingEntity(j => j.HasData(
                    new { ModulesId = 1, ComponentsId = 1 },
                    new { ModulesId = 1, ComponentsId = 2 },
                    new { ModulesId = 2, ComponentsId = 1 }
                    ));

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Collection>().ToTable("Collection");
            modelBuilder.Entity<Collection>().HasData(collections);

            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<Module>().HasData(modules);

            modelBuilder.Entity<Component>().ToTable("Component");
            modelBuilder.Entity<Component>().HasData(components);
        }
    }
}
