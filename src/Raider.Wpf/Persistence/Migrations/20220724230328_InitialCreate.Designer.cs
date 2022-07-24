﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raider.Wpf.Persistence;

#nullable disable

namespace Raider.Wpf.Persistence.Migrations
{
    [DbContext(typeof(RaiderDbContext))]
    [Migration("20220724230328_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Raider.Domain.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsSaved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("MainId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("MainId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Raider.Domain.Entities.CharacterSpecialisation", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialisationId")
                        .HasColumnType("TEXT");

                    b.Property<float?>("GearScore")
                        .HasColumnType("REAL");

                    b.HasKey("CharacterId", "SpecialisationId");

                    b.HasIndex("SpecialisationId");

                    b.ToTable("CharacterSpecialisations");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Class", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Encounter", b =>
                {
                    b.Property<Guid>("RaidId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaidSetupId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaidId", "CharacterId", "RaidSetupId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RaidSetupId");

                    b.ToTable("Encounters");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Raid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Players")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Raids");
                });

            modelBuilder.Entity("Raider.Domain.Entities.RaidSetup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RaidId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Template")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RaidId");

                    b.ToTable("RaidSetups");
                });

            modelBuilder.Entity("Raider.Domain.Entities.RaidSetupMap", b =>
                {
                    b.Property<Guid>("RaidSetupId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialisationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Group")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.HasKey("RaidSetupId", "SpecialisationId", "Group", "Index");

                    b.HasIndex("SpecialisationId");

                    b.ToTable("RaidSetupMaps");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Specialisation", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RoleId");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Character", b =>
                {
                    b.HasOne("Raider.Domain.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.Character", "Main")
                        .WithMany()
                        .HasForeignKey("MainId");

                    b.Navigation("Class");

                    b.Navigation("Main");
                });

            modelBuilder.Entity("Raider.Domain.Entities.CharacterSpecialisation", b =>
                {
                    b.HasOne("Raider.Domain.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.Specialisation", "Specialisation")
                        .WithMany()
                        .HasForeignKey("SpecialisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Specialisation");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Encounter", b =>
                {
                    b.HasOne("Raider.Domain.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.Raid", "Raid")
                        .WithMany()
                        .HasForeignKey("RaidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.RaidSetup", "RaidSetup")
                        .WithMany()
                        .HasForeignKey("RaidSetupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Raid");

                    b.Navigation("RaidSetup");
                });

            modelBuilder.Entity("Raider.Domain.Entities.RaidSetup", b =>
                {
                    b.HasOne("Raider.Domain.Entities.Raid", "Raid")
                        .WithMany()
                        .HasForeignKey("RaidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Raid");
                });

            modelBuilder.Entity("Raider.Domain.Entities.RaidSetupMap", b =>
                {
                    b.HasOne("Raider.Domain.Entities.RaidSetup", "RaidSetup")
                        .WithMany()
                        .HasForeignKey("RaidSetupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.Specialisation", "Specialisation")
                        .WithMany()
                        .HasForeignKey("SpecialisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaidSetup");

                    b.Navigation("Specialisation");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Specialisation", b =>
                {
                    b.HasOne("Raider.Domain.Entities.Class", "Class")
                        .WithMany("Specialisations")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raider.Domain.Entities.Role", "Role")
                        .WithMany("Specialisations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Class", b =>
                {
                    b.Navigation("Specialisations");
                });

            modelBuilder.Entity("Raider.Domain.Entities.Role", b =>
                {
                    b.Navigation("Specialisations");
                });
#pragma warning restore 612, 618
        }
    }
}