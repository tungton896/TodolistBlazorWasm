using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListBlazor.Api.Entities;

namespace TodoListBlazor.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async System.Threading.Tasks.Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Name",
                    CreatedDate = DateTime.Now,
                    Priority = Enums.Priority.High,
                    Status = Enums.Status.Open
                });
            }
            if (!context.Users.Any())
            {
                var admin = new Entities.User()
                {
                    Id = Guid.NewGuid(),
                    FirtName = "Mr",
                    LastName = "A",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456789",
                    UserName = "Admin"
                };
                admin.PasswordHash = _passwordHasher.HashPassword(admin, "123456789");
                context.Users.Add(admin);

            }
            await context.SaveChangesAsync();
        }
    }
}
