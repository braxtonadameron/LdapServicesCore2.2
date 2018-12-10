using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LdapServices.Models {
    public class LdapDatabaseContext : DbContext {
        public LdapDatabaseContext(DbContextOptions<LdapDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Assigned
            modelBuilder.Entity<AssignedTag>()
                .HasKey(t => new { t.BannerId, t.TagName });

            modelBuilder.Entity<AssignedTag>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.AssignedTags)
                .HasForeignKey(pt => pt.BannerId);

            modelBuilder.Entity<AssignedTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.AssignedTags)
                .HasForeignKey(pt => pt.TagName);

            // Priviledges
            modelBuilder.Entity<AssignedPriviledge>()
                .HasKey(t => new { t.AccessName, t.TagName });

            modelBuilder.Entity<AssignedPriviledge>()
                .HasOne(pt => pt.Access)
                .WithMany(p => p.AssignedPriviledges)
                .HasForeignKey(pt => pt.AccessName);

            modelBuilder.Entity<AssignedPriviledge>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.AssignedPriviledges)
                .HasForeignKey(pt => pt.TagName);

            // Works_On
            modelBuilder.Entity<WorksOn>()
                .HasKey(t => new { t.ProcessName, t.TagName });

            modelBuilder.Entity<WorksOn>()
                .HasOne(pt => pt.Process)
                .WithMany(p => p.WorksOns)
                .HasForeignKey(pt => pt.ProcessName);

            modelBuilder.Entity<WorksOn>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.WorksOns)
                .HasForeignKey(pt => pt.TagName);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Process> Processes { get; set; }
    }

    public class User {
        [Key]
        public string BannerId { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BusinessAddress { get; set; }
        public bool DisplayInDirectory { get; set; }
        public bool EmailNotification { get; set; }

        public ICollection<AssignedTag> AssignedTags { get; set; }
    }

    public class Tag {
        [Key]
        public string TagName { get; set; }

        public string TagDescription { get; set; }

        [JsonIgnore]
        public ICollection<AssignedTag> AssignedTags { get; set; }
        public ICollection<AssignedPriviledge> AssignedPriviledges { get; set; }
        public ICollection<WorksOn> WorksOns { get; set; }
    }

    public class Access {
        [Key]
        public string AccessName { get; set; }

        public string AccessDescription { get; set; }

        public ICollection<AssignedPriviledge> AssignedPriviledges { get; set; }
    }

    public class Process {
        [Key]
        public string ProcessName { get; set; }

        public string ProcessDescription { get; set; }

        public ICollection<WorksOn> WorksOns { get; set; }
    }

    public class AssignedTag {
        public string BannerId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public string TagName { get; set; }
        public Tag Tag { get; set; }
    }

    public class AssignedPriviledge {
        public string TagName { get; set; }
        public Tag Tag { get; set; }

        public string AccessName { get; set; }
        public Access Access { get; set; }
    }

    public class WorksOn {
        public string TagName { get; set; }
        public Tag Tag { get; set; }

        public string ProcessName { get; set; }
        public Process Process { get; set; }
    }
}
