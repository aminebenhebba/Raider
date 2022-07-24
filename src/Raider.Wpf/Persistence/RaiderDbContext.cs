using Microsoft.EntityFrameworkCore;
using Raider.Domain.Entities;

namespace Raider.Wpf.Persistence
{
    public class RaiderDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSpecialisation> CharacterSpecialisations { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Raid> Raids { get; set; }
        public DbSet<RaidSetup> RaidSetups { get; set; }
        public DbSet<RaidSetupMap> RaidSetupMaps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }

        public RaiderDbContext(DbContextOptions<RaiderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.IsMain)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(e => e.IsSaved)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.HasOne(nav => nav.Main)
                    .WithMany()
                    .HasForeignKey(e => e.MainId);

                entity.HasOne(nav => nav.Class)
                    .WithMany()
                    .HasForeignKey(e => e.ClassId)
                    .IsRequired();
            });

            modelBuilder.Entity<CharacterSpecialisation>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.SpecialisationId });

                entity.Property(e => e.GearScore);

                entity.HasOne(nav => nav.Character)
                    .WithMany()
                    .HasForeignKey(e => e.CharacterId)
                    .IsRequired();

                entity.HasOne(nav => nav.Specialisation)
                    .WithMany()
                    .HasForeignKey(e => e.SpecialisationId)
                    .IsRequired();
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(50);

                entity.Property(e => e.Icon)
                    .HasMaxLength(100);

                entity.HasMany(nav => nav.Specialisations)
                    .WithOne(nav => nav.Class)
                    .HasForeignKey(e => e.ClassId)
                    .IsRequired();
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.HasKey(e => new { e.RaidId, e.CharacterId, e.RaidSetupId });

                entity.Property(e => e.Day)
                    .IsRequired();

                entity.HasOne(nav => nav.Character)
                    .WithMany()
                    .HasForeignKey(e => e.CharacterId)
                    .IsRequired();

                entity.HasOne(nav => nav.Raid)
                    .WithMany()
                    .HasForeignKey(e => e.RaidId)
                    .IsRequired();

                entity.HasOne(nav => nav.RaidSetup)
                    .WithMany()
                    .HasForeignKey(e => e.RaidSetupId)
                    .IsRequired();
            });

            modelBuilder.Entity<Raid>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Players)
                    .IsRequired();

                entity.Property(e => e.Logo)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RaidSetup>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(nav => nav.Raid)
                    .WithMany()
                    .HasForeignKey(e => e.RaidId)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Template)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RaidSetupMap>(entity =>
            {
                entity.HasKey(e => new { e.RaidSetupId, e.SpecialisationId, e.Group, e.Index });

                entity.HasOne(nav => nav.RaidSetup)
                    .WithMany()
                    .HasForeignKey(e => e.RaidSetupId)
                    .IsRequired();

                entity.HasOne(nav => nav.Specialisation)
                    .WithMany()
                    .HasForeignKey(e => e.SpecialisationId)
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(50);

                entity.Property(e => e.Icon)
                    .HasMaxLength(100);

                entity.HasMany(nav => nav.Specialisations)
                    .WithOne(nav => nav.Role)
                    .HasForeignKey(e => e.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<Specialisation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(50);

                entity.HasOne(nav => nav.Class)
                    .WithMany(nav => nav.Specialisations)
                    .HasForeignKey(e => e.ClassId)
                    .IsRequired();

                entity.HasOne(nav => nav.Role)
                    .WithMany(nav => nav.Specialisations)
                    .HasForeignKey(e => e.RoleId)
                    .IsRequired();

                entity.Property(e => e.Icon)
                    .HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}