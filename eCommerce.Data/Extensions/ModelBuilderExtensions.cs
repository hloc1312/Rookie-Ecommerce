using eCommerce.Data.Entities;
using eCommerce.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    Id = 1,
                    SortOrder = 1, 
                    IsShowOnHome = true, 
                    ParentId = null, 
                    Status = Status.Active,
                    Name = "Áo Thun Nam",
                    SeoAlias = "ao-thun-nam",
                    SeoDescription = "Áo Thun Thời Trang Dành Cho Nam",
                    SeoTitle = "Áo Thun Nam" },
                new Category()
                {
                    Id = 2,
                    SortOrder = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    Status = Status.Active,
                    Name = "Áo Nữ",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Áo Thời Trang Dành Cho Nữ",
                    SeoTitle = "Áo Nữ"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product() { 
                    Id = 1,
                    DateCreate = DateTime.Now, 
                    OriginalPrice = 100000, 
                    Price = 200000, 
                    Quantity = 0, 
                    ViewCount = 0,
                    Name = "Áo Thun Nam Cá Sấu",
                    SeoAlias = "ao-thun-nam",
                    SeoDescription = "Áo Thun Thời Trang Dành Cho Nam",
                    SeoTitle = "Áo Thun Nam",
                    Details = "Áo thun nam cá sấu",
                    Description = "Áo thun nam cá sấu"

                },
                new Product()
                {
                    Id = 2,
                    DateCreate = DateTime.Now,
                    OriginalPrice = 50000,
                    Price = 150000,
                    Quantity = 0,
                    ViewCount = 0,
                    Name = "Áo Nữ",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Áo Thời Trang Dành Cho Nữ",
                    SeoTitle = "Áo Nữ",
                    Details = "Áo nữ",
                    Description = "Áo nữ"

                }
            );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { CategoryId = 1, ProductId = 1 },
                new ProductInCategory() { CategoryId = 2, ProductId = 2 }
                );


            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hloc878@gmail.com",
                NormalizedEmail = "hloc878@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Nguyen",
                LastName = "Loc",
                Birthday = new DateTime(2000, 12, 13)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
