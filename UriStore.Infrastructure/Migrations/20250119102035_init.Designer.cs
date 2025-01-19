﻿// <auto-generated />
using System;
using UriStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UriStore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250119102035_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UriStore.Domain.Entities.EmailConfirmationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailConfirmationTokens");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "STaff"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("UriStore.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Address = "Ninh Kiều, Cần Thơ",
                            CreatedAt = new DateTime(2025, 1, 19, 10, 20, 34, 972, DateTimeKind.Utc).AddTicks(3318),
                            Email = "admin@gmail.com",
                            FullName = "admin",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 10, 20, 34, 972, DateTimeKind.Utc).AddTicks(3323),
                            PasswordHash = "$2a$11$Nha6sbTXuTwuVQTPWeioOuenNFlydhqvdvUuG0JIHUpJOjo3ksPRO",
                            Phone = "0987654321",
                            RoleId = 1
                        },
                        new
                        {
                            Id = new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                            Address = "Bình Thủy, Cần Thơ",
                            CreatedAt = new DateTime(2025, 1, 19, 10, 20, 35, 94, DateTimeKind.Utc).AddTicks(6689),
                            Email = "staff@gmail.com",
                            FullName = "staff",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 10, 20, 35, 94, DateTimeKind.Utc).AddTicks(6694),
                            PasswordHash = "$2a$11$K2ljjW0KLTPTuBc/Y8XkKOWogqiRNwbhrIZ60rD8zA9F9fRJ6QauK",
                            Phone = "0987654123",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                            Address = "Phong Điền, Cần Thơ",
                            CreatedAt = new DateTime(2025, 1, 19, 10, 20, 35, 225, DateTimeKind.Utc).AddTicks(1997),
                            Email = "user@gmail.com",
                            FullName = "user",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 10, 20, 35, 225, DateTimeKind.Utc).AddTicks(2009),
                            PasswordHash = "$2a$11$gp.29SS.au.nX8aFps57NeALwFWUlk0/beqIrLRAX0vjRNG9VvF3y",
                            Phone = "0987654312",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("UriStore.Domain.Entities.EmailConfirmationToken", b =>
                {
                    b.HasOne("UriStore.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("UriStore.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.User", b =>
                {
                    b.HasOne("UriStore.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
