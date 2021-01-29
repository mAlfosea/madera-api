﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using madera_api.Data;

namespace madera_api.Migrations
{
    [DbContext(typeof(DbMainContext))]
    partial class DbMainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CollectionModule", b =>
                {
                    b.Property<int>("CollectionsId")
                        .HasColumnType("int");

                    b.Property<int>("ModulesId")
                        .HasColumnType("int");

                    b.HasKey("CollectionsId", "ModulesId");

                    b.HasIndex("ModulesId");

                    b.ToTable("CollectionModule");
                });

            modelBuilder.Entity("ComponentModule", b =>
                {
                    b.Property<int>("ComponentsId")
                        .HasColumnType("int");

                    b.Property<int>("ModulesId")
                        .HasColumnType("int");

                    b.HasKey("ComponentsId", "ModulesId");

                    b.HasIndex("ModulesId");

                    b.ToTable("ComponentModule");
                });

            modelBuilder.Entity("madera_api.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("madera_api.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Nature")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nature");

                    b.Property<double>("Price")
                        .HasMaxLength(100)
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("Trait")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("trait");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("unite");

                    b.HasKey("Id");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("madera_api.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Nature")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nature");

                    b.Property<string>("Trait")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("trait");

                    b.Property<string>("Unite")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("unite");

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("madera_api.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Amount")
                        .HasColumnType("real")
                        .HasColumnName("amount");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit")
                        .HasColumnName("IsPaid");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("madera_api.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("CommercialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommercialId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("madera_api.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("CommercialId")
                        .HasColumnType("int");

                    b.Property<byte[]>("CreationDate")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("creation-date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("CommercialId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Proposal");
                });

            modelBuilder.Entity("madera_api.Models.ProposalModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ProposalId");

                    b.ToTable("ProposalModule");
                });

            modelBuilder.Entity("madera_api.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("label");

                    b.Property<int>("Percent")
                        .HasColumnType("int")
                        .HasColumnName("percent");

                    b.HasKey("Id");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("madera_api.Models.StepProject", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "StepId", "PaymentId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StepId");

                    b.ToTable("StepProject");
                });

            modelBuilder.Entity("madera_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Civility")
                        .HasColumnType("int")
                        .HasColumnName("civility");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("phone");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CollectionModule", b =>
                {
                    b.HasOne("madera_api.Models.Collection", null)
                        .WithMany()
                        .HasForeignKey("CollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComponentModule", b =>
                {
                    b.HasOne("madera_api.Models.Component", null)
                        .WithMany()
                        .HasForeignKey("ComponentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("madera_api.Models.Project", b =>
                {
                    b.HasOne("madera_api.Models.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("madera_api.Models.User", "Commercial")
                        .WithMany()
                        .HasForeignKey("CommercialId");

                    b.Navigation("Client");

                    b.Navigation("Commercial");
                });

            modelBuilder.Entity("madera_api.Models.Proposal", b =>
                {
                    b.HasOne("madera_api.Models.User", "Commercial")
                        .WithMany()
                        .HasForeignKey("CommercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commercial");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("madera_api.Models.ProposalModule", b =>
                {
                    b.HasOne("madera_api.Models.Module", "Module")
                        .WithMany("ProposalModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Proposal", "Proposal")
                        .WithMany("ProposalModules")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("madera_api.Models.StepProject", b =>
                {
                    b.HasOne("madera_api.Models.Payment", "Payment")
                        .WithMany("StepProjects")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Project", "Project")
                        .WithMany("StepProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("madera_api.Models.Step", "Step")
                        .WithMany("StepProjects")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Project");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("madera_api.Models.Module", b =>
                {
                    b.Navigation("ProposalModules");
                });

            modelBuilder.Entity("madera_api.Models.Payment", b =>
                {
                    b.Navigation("StepProjects");
                });

            modelBuilder.Entity("madera_api.Models.Project", b =>
                {
                    b.Navigation("StepProjects");
                });

            modelBuilder.Entity("madera_api.Models.Proposal", b =>
                {
                    b.Navigation("ProposalModules");
                });

            modelBuilder.Entity("madera_api.Models.Step", b =>
                {
                    b.Navigation("StepProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
