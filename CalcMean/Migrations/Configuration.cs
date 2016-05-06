using CalcMean.Models;
using Microsoft.AspNet.Identity;

namespace CalcMean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CmContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var hasher = new PasswordHasher();
            var pass = hasher.HashPassword("111111");


            context.Users.AddOrUpdate(
              p => p.Id,
              new CmUser { UserName = "ChinhDD", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Đỗ Đức Chính", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },              
              new CmUser { UserName = "XuyenHTK", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Kim Xuyến", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },
              new CmUser { UserName = "HuyenVV", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Huyền Vũ", CreateDate = DateTime.Now, PhoneNumber = "0973561921" },
              new CmUser { UserName = "HoaiNK", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Khắc Hoài", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },
              new CmUser { UserName = "HongTD", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Hồng Trần", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },
              new CmUser { UserName = "HoanNC", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Công Hoan", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },
              new CmUser { UserName = "MinhNH", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Minh Đệ", CreateDate = DateTime.Now, PhoneNumber = "0979999899" },
              new CmUser { UserName = "Hang", SecurityStamp = Guid.NewGuid().ToString(), PasswordHash = pass, Name = "Hằng", CreateDate = DateTime.Now, PhoneNumber = "0979999899" }
            );
        }
    }
}
