using UriStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace UriStore.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmailConfirmationToken> EmailConfirmationTokens { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>()
                .HasData(
                    new Role() { Id = 1, Name = "Admin"},
                    new Role() { Id = 2, Name = "STaff"},
                    new Role() { Id = 3, Name = "User"}
                );

            Guid adminId = new("d87b4b72-609b-4979-b758-7771481da883");
            Guid staffId = new("4b7b0200-70f9-416a-9a3f-29ccab0deec4");
            Guid userId = new("a85f272f-353e-4ff6-be2b-a15f1e7c0c47");

            builder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = adminId,
                        Email = "admin@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "admin",
                        Address = "Ninh Kiều, Cần Thơ",
                        Phone = "0987654321",
                        IsEmailConfirmed = true,
                        RoleId = 1
                    },
                    new User()
                    {
                        Id = staffId,
                        Email = "staff@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "staff",
                        Address = "Bình Thủy, Cần Thơ",
                        Phone = "0987654123",
                        IsEmailConfirmed = true,
                        RoleId = 2
                    },
                    new User()
                    {
                        Id = userId,
                        Email = "user@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "user",
                        Address = "Phong Điền, Cần Thơ",
                        Phone = "0987654312",
                        IsEmailConfirmed = true,
                        RoleId = 3
                    }
            );

            builder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Coffee", CreatedById = adminId, LastModifiedById = adminId },
                    new Category { Id = 2, Name = "Tea", CreatedById = adminId, LastModifiedById = adminId },
                    new Category { Id = 3, Name = "Banh Mi", CreatedById = adminId, LastModifiedById = adminId },
                    new Category { Id = 4, Name = "Other", CreatedById = adminId, LastModifiedById = adminId }
            );

            builder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201"),
                        Name = "PhinDi Cassia",
                        Description = "Với chất phin êm ái, hương vị cà phê Việt Nam hiện đại kết hợp cùng hương quế nhẹ nhàng và thạch cà phê hấp dẫn.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                        CategoryId = 1,
                        Price = 55000,
                        Discount = 0,
                        Quantity = 325,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202"),
                        Name = "Phindi Hạt Dẻ Cười",
                        Description = "PhinDi Hạt Dẻ Cười - Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp sốt phistiachio mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                        CategoryId = 1,
                        Price = 65000,
                        Discount = 5,
                        Quantity = 0,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f203"),
                        Name = "PhinDi Choco",
                        Description = "Cà phê Phin thế hệ mới với chất Phin êm hơn, kết hợp cùng Choco ngọt tan mang đến hương vị mới lạ, không thể hấp dẫn hơn!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__PHINDI_CHOCO.jpg",
                        CategoryId = 1,
                        Price = 45000,
                        Discount = 0,
                        Quantity = 5,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f204"),
                        Name = "Golden Lotus Tea (Only Lotus seed)",
                        Description = "Golden Lotus Tea (Only Lotus seed)",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TSV.jpg",
                        CategoryId = 2,
                        Price = 45000,
                        Discount = 0,
                        Quantity = 214,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f205"),
                        Name = "Peach Jelly Tea",
                        Description = "A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2023/HLC_New_logo_5.1_Products__TRA_THANH_DAO-09.jpg",
                        CategoryId = 2,
                        Price = 45000,
                        Discount = 10,
                        Quantity = 45,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f206"),
                        Name = "Bánh Mì Que (Gà Phô Mai)",
                        Description = "Bánh mì que gà tại Highlands Coffee mang đến hương vị đậm đà kết hợp với phô mai beo béo, không chỉ ngon miệng mà còn bổ dưỡng, phù hợp cho bữa ăn nhanh gọn.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Ga_Pho_Mai.png",
                        CategoryId = 3,
                        Price = 19000,
                        Discount = 0,
                        Quantity = 34,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f208"),
                        Name = "Bánh Mì Que (Pate)",
                        Description = "Thưởng thức hương vị truyền thống với bánh mì que pate tại Highlands Coffee. Bánh mì giòn tan, kết hợp với pate thơm ngon, tạo nên một món ăn sáng hoàn hảo cho mọi người.",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/11_2024/2024_Food/BMQ_Pate.png",
                        CategoryId = 3,
                        Price = 19000,
                        Discount = 0,
                        Quantity = 146,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    },
                    new Product
                    {
                        Id = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209"),
                        Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                        Description = "Bò xốt vang - Một sự kết hợp mới lạ giữa hương vị thơm ngon của bò xốt vang và bánh trung thu truyền thống, mang đến một vị ngon đầy đặc sắc và độc đáo..\r\n\r\nĐẶT GIAO NGAY HOẶC GỌI 1900 1755\r\n\r\nLƯU Ý:\r\n\r\nBánh chỉ bán ở 6 tỉnh thành: Hồ Chí Minh, Hà Nội, Đà Nẵng, Đồng Nai, Bình Dương và Vũng Tàu (trừ các cửa hàng kiosk và sân bay quốc tế)",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                        CategoryId = 4,
                        Price = 109000,
                        Discount = 3,
                        Quantity = 214,
                        CreatedById = adminId,
                        LastModifiedById = adminId,
                    }
                );

            long orderId = long.Parse(DateTime.UtcNow.ToString("yyyyMMdd") + "000001");

            builder.Entity<Order>()
                .HasData(
                    new Order()
                    {
                        Id = orderId,
                        FullName = "Huỳnh Hữu Nghĩa",
                        Phone = "0832474699",
                        Address = "Cần Thơ",
                        DiscountFee = 0,
                        ShippingFee = 32000,
                        VoucherCode = "NGHIAHH",
                        VoucherName = "Voucher 28/08",
                        VoucherValue = 24,
                        Note = "Giao hàng nhanh",
                        Status = Domain.Enums.OrderStatus.PENDING,
                        TotalPrice = 289814,
                        CreatedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                        LastModifiedById = new Guid("d87b4b72-609b-4979-b758-7771481da883"),
                    }
                );

            builder.Entity<OrderDetail>()
                .HasData(
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "PhinDi Cassia",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/06_2024/Phindi_Cassia/Phindi_Cassia_Highlands_products_Image1.jpg",
                        Category = "Coffee",
                        Price = 55000,
                        Discount = 0,
                        Quantity = 2,
                        OrderId = orderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f201")
                    },
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "Phindi Hạt Dẻ Cười",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2023/Phindi_Pitaschio.jpg",
                        Category = "Coffee",
                        Price = 65000,
                        Discount = 5,
                        Quantity = 2,
                        OrderId = orderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f202")
                    },
                    new OrderDetail
                    {
                        Id = Guid.NewGuid(),
                        Name = "BÁNH TRUNG THU - BÒ XỐT VANG - HIGHLANDS COFFEE",
                        Photo = "https://www.highlandscoffee.com.vn/vnt_upload/product/08_2024/Mooncake/MOONCAKES_PRODUCTSBO-XOT-VANG.png",
                        Category = "Other",
                        Price = 109000,
                        Discount = 3,
                        Quantity = 1,
                        OrderId = orderId,
                        ProductId = new Guid("868e6f06-9728-48c3-a5d7-5d1aadf4f209")
                    }
                );
        }
    }
}
