using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class SeedData
    {
        public static async Task Seed(DataContext context)
        {
            if (!context.Activities.Any())
            {
                List<Activity> sample = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Annual Meet",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Annual Meet 8 months in future",
                        Category = "business",
                        City = "Mumbai",
                        Venue = "Hotel",
                        IsCancelled = false
                    },
                    new Activity
                    {
                        Title = "Seminar",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Seminar 1 months in future",
                        Category = "business",
                        City = "Mumbai",
                        Venue = "Hotel",
                        IsCancelled = false
                    },
                    new Activity
                    {
                        Title = "Party",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Party 2 months in future",
                        Category = "function",
                        City = "Mumbai",
                        Venue = "Hotel",
                        IsCancelled = false
                    }
                };
                context.Activities.AddRange(sample);
                await context.SaveChangesAsync();
            }
        }
    }
}
