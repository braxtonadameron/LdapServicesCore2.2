﻿// <auto-generated />
using LdapServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LdapServicesCore2._2.Migrations
{
    [DbContext(typeof(LdapDatabaseContext))]
    [Migration("20181210030313_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LdapServices.Models.Access", b =>
                {
                    b.Property<string>("AccessName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessDescription");

                    b.HasKey("AccessName");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("LdapServices.Models.AssignedPriviledge", b =>
                {
                    b.Property<string>("AccessName");

                    b.Property<string>("TagName");

                    b.HasKey("AccessName", "TagName");

                    b.HasIndex("TagName");

                    b.ToTable("AssignedPriviledge");
                });

            modelBuilder.Entity("LdapServices.Models.AssignedTag", b =>
                {
                    b.Property<string>("BannerId");

                    b.Property<string>("TagName");

                    b.HasKey("BannerId", "TagName");

                    b.HasIndex("TagName");

                    b.ToTable("AssignedTag");
                });

            modelBuilder.Entity("LdapServices.Models.Process", b =>
                {
                    b.Property<string>("ProcessName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProcessDescription");

                    b.HasKey("ProcessName");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("LdapServices.Models.Tag", b =>
                {
                    b.Property<string>("TagName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagDescription");

                    b.HasKey("TagName");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("LdapServices.Models.User", b =>
                {
                    b.Property<string>("BannerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessAddress");

                    b.Property<bool>("DisplayInDirectory");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailNotification");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("BannerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LdapServices.Models.WorksOn", b =>
                {
                    b.Property<string>("ProcessName");

                    b.Property<string>("TagName");

                    b.HasKey("ProcessName", "TagName");

                    b.HasIndex("TagName");

                    b.ToTable("WorksOn");
                });

            modelBuilder.Entity("LdapServices.Models.AssignedPriviledge", b =>
                {
                    b.HasOne("LdapServices.Models.Access", "Access")
                        .WithMany("AssignedPriviledges")
                        .HasForeignKey("AccessName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LdapServices.Models.Tag", "Tag")
                        .WithMany("AssignedPriviledges")
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LdapServices.Models.AssignedTag", b =>
                {
                    b.HasOne("LdapServices.Models.User", "User")
                        .WithMany("AssignedTags")
                        .HasForeignKey("BannerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LdapServices.Models.Tag", "Tag")
                        .WithMany("AssignedTags")
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LdapServices.Models.WorksOn", b =>
                {
                    b.HasOne("LdapServices.Models.Process", "Process")
                        .WithMany("WorksOns")
                        .HasForeignKey("ProcessName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LdapServices.Models.Tag", "Tag")
                        .WithMany("WorksOns")
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
