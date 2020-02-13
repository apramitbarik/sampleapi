using System;
using TodoApi.Models;

namespace TodoApi.IntegrationTest
{
    public class SeedData
    {
        public static void PopulateTestData(TodoContext dbContext)
        {
            dbContext.TodoItems.Add(new TodoItem(){
                Id = 1,
                Name = "walk dog",
                IsComplete = true
            });
            dbContext.SaveChanges();
        }
    }
}