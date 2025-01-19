﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UriStore.Infrastructure.Context;

#nullable disable

namespace UriStore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UriStore.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3414),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3418),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Coffee"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3426),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3426),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Tea"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3428),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3428),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Banh Mi"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3429),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3429),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Other"
                        });
                });

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

            modelBuilder.Entity("UriStore.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3464),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3464),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "PhinDi Cassia",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                            Price = 55000,
                            Quantity = 325
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3486),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                            Discount = 5,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3486),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Phindi Hạt Dẻ Cười",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                            Price = 65000,
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                            CategoryId = 1,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3490),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3490),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "PhinDi Choco",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg",
                            Price = 45000,
                            Quantity = 5
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                            CategoryId = 2,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3493),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Golden Lotus Tea (Only Lotus seed)",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3493),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Golden Lotus Tea (Only Lotus seed)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg",
                            Price = 45000,
                            Quantity = 214
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                            CategoryId = 2,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3497),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!",
                            Discount = 10,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3498),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Peach Jelly Tea",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg",
                            Price = 45000,
                            Quantity = 45
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                            CategoryId = 3,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3502),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3502),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Bánh Mì Que (Gà Phô Mai)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png",
                            Price = 19000,
                            Quantity = 34
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                            CategoryId = 3,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3505),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.",
                            Discount = 0,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3505),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "Bánh Mì Que (Pate)",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png",
                            Price = 19000,
                            Quantity = 146
                        },
                        new
                        {
                            Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                            CategoryId = 4,
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3508),
                            CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Description = "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)",
                            Discount = 3,
                            IsDeleted = false,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 615, DateTimeKind.Utc).AddTicks(3508),
                            LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                            Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                            Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                            Price = 109000,
                            Quantity = 214
                        });
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
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 268, DateTimeKind.Utc).AddTicks(7993),
                            Email = "admin@gmail.com",
                            FullName = "admin",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 268, DateTimeKind.Utc).AddTicks(7995),
                            PasswordHash = "$2a$11$7fGWNzMwM8lYbf9LHrWzguCzet59Mh/zhM6xOeoos9ZbAZ/BY4/HW",
                            Phone = "0987654321",
                            RoleId = 1
                        },
                        new
                        {
                            Id = new Guid("4b7b0200-70f9-416a-9a3f-29ccab0deec4"),
                            Address = "Bình Thủy, Cần Thơ",
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 382, DateTimeKind.Utc).AddTicks(2175),
                            Email = "staff@gmail.com",
                            FullName = "staff",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 382, DateTimeKind.Utc).AddTicks(2181),
                            PasswordHash = "$2a$11$Djs/yoOLqyFbq6L2CaTbIOwl9UeeAVy.5MpUg1PiUISavYCk.TiJi",
                            Phone = "0987654123",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("a85f272f-353e-4ff6-be2b-a15f1e7c0c47"),
                            Address = "Phong Điền, Cần Thơ",
                            CreatedAt = new DateTime(2025, 1, 19, 15, 51, 32, 498, DateTimeKind.Utc).AddTicks(9237),
                            Email = "user@gmail.com",
                            FullName = "user",
                            IsDeleted = false,
                            IsEmailConfirmed = true,
                            LastModifiedAt = new DateTime(2025, 1, 19, 15, 51, 32, 498, DateTimeKind.Utc).AddTicks(9242),
                            PasswordHash = "$2a$11$ACun7mTyhjmJyPsYVRyxQedMPo5D7IbMM6y7yCtFR8euN8QoFi5Vi",
                            Phone = "0987654312",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("UriStore.Domain.Entities.Category", b =>
                {
                    b.HasOne("UriStore.Domain.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UriStore.Domain.Entities.User", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
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

            modelBuilder.Entity("UriStore.Domain.Entities.Product", b =>
                {
                    b.HasOne("UriStore.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UriStore.Domain.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UriStore.Domain.Entities.User", "LastModifiedBy")
                        .WithMany()
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
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

            modelBuilder.Entity("UriStore.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("UriStore.Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
