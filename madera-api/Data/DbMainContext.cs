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
        public DbSet<Step> Step { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<StepProject> StepProject { get; set; }
        public DbSet<Proposal> Proposal { get; set; }
        public DbSet<ProposalModule> ProposalModule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepProject>()
                .HasKey(t => new { t.ProjectId, t.StepId, t.PaymentId });

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Step)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.StepId);

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Payment)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.PaymentId);


            modelBuilder.Entity<ProposalModule>()
            .HasOne(pt => pt.Proposal)
            .WithMany(p => p.ProposalModules)
            .HasForeignKey(pt => pt.ProposalId);

            modelBuilder.Entity<ProposalModule>()
            .HasOne(pt => pt.Module)
            .WithMany(p => p.ProposalModules)
            .HasForeignKey(pt => pt.ModuleId);


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
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasData(users);

            /*var modules = new[]
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

            var projects = new[]
            {
                new Project
                {
                    Id = 1,
                    Name = "Projet de Francis",
                    ClientId = users[0].Id,
                    CommercialId = users[1].Id,
                }
            };

            var steps = new[]
            {
                new Step
                {
                    Id = 1,
                    Label = "Phase de proposition",
                    Percent = 0
                }
            };

            var payments = new[]
            {
                new Payment
                {
                    Id = 1,
                    IsPaid = true,
                    Amount = 0
                }
            };

            var stepProjects = new[]
            {
                new StepProject
                {
                    ProjectId = projects[0].Id,
                    PaymentId = payments[0].Id,
                    StepId = steps[0].Id
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

            modelBuilder.Entity<StepProject>()
                .HasKey(t => new { t.ProjectId, t.StepId, t.PaymentId });

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Step)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.StepId);

            modelBuilder.Entity<StepProject>()
            .HasOne(pt => pt.Payment)
            .WithMany(p => p.StepProjects)
            .HasForeignKey(pt => pt.PaymentId);

            modelBuilder.Entity<Project>()
            .HasOne(pt => pt.Client).WithMany(c => c.ClientProjects).HasForeignKey(pt => pt.ClientId);

            modelBuilder.Entity<Project>()
            .HasOne(pt => pt.Commercial).WithMany(c => c.CommercialProjects).HasForeignKey(pt => pt.CommercialId);


            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Collection>().ToTable("Collection");
            modelBuilder.Entity<Collection>().HasData(collections);

            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<Module>().HasData(modules);

            modelBuilder.Entity<Component>().ToTable("Component");
            modelBuilder.Entity<Component>().HasData(components);

            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Project>().HasData(projects);

            /*modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Payment>().HasData(payments);

            modelBuilder.Entity<Step>().ToTable("Step");
            modelBuilder.Entity<Step>().HasData(steps);

            modelBuilder.Entity<StepProject>().ToTable("StepProject");
            modelBuilder.Entity<StepProject>().HasData(stepProjects);*/
        }
    }
}
