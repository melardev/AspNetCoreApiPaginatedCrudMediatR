using System;
using System.Threading.Tasks;
using ApiCrudPaginationMediatR.Data;
using ApiCrudPaginationMediatR.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPaginationMediatR.Seeds
{
    public class DbSeeder
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            await SeedTodos(context);
        }

        public static async Task SeedTodos(ApplicationDbContext context)
        {
            var todosCount = await context.Todos.CountAsync();
            var todosToSeed = 32;
            todosToSeed -= todosCount;
            if (todosToSeed > 0)
            {
                Console.WriteLine($"[+] Seeding ${todosToSeed} Todos");
                var faker = new Faker<Todo>()
                    .RuleFor(a => a.Title, f => string.Join(" ", f.Lorem.Words(f.Random.Int(2, 5))))
                    .RuleFor(a => a.Description, f => f.Lorem.Sentences(f.Random.Int(1, 10)))
                    .RuleFor(t => t.Completed, f => f.Random.Bool(0.4f))
                    .RuleFor(a => a.CreatedAt, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now.AddDays(-1)))
                    .FinishWith((f, todoInstance) =>
                    {
                        todoInstance.UpdatedAt = f.Date.Between(todoInstance.CreatedAt, DateTime.Now);
                    });

                var todos = faker.Generate(todosToSeed);
                await context.Todos.AddRangeAsync(todos);
                await context.SaveChangesAsync();
            }
        }
    }
}