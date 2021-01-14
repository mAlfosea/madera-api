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
        }
    }
}
