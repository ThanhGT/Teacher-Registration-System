using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Tran_Thanh_991515427_Exam.Models;

namespace Tran_Thanh_991515427_Exam.Models
{
    public class SeedData
    {
        // receive an IApplication Builder argument(is an interface used in the Configure method in Startup.cs to register
        // middleware's to handle HTTP requests)
        //need to make it connects to the database in the Startup.cs
        public static void DataPopulated(IApplicationBuilder app)
        {
            MBS_DBContext context = app.ApplicationServices
                                    .CreateScope().ServiceProvider
                                    .GetRequiredService<MBS_DBContext>();

            //check if there are any pending migrations and if there are then do all the migrations (found in migration folder)
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                new Teacher
                {
                    FirstName = "Paul",
                    LastName = "Bonenfant",
                    Salary = 85000
                },
                new Teacher
                {
                    FirstName = "Elizabeth",
                    LastName = "Dancy",
                    Salary = 82000
                },
                new Teacher
                {
                    FirstName = "Yash",
                    LastName = "Shah",
                    Salary = 72000
                },
                new Teacher
                {
                    FirstName = "John",
                    LastName = "Dafoe",
                    Salary = 77000
                },
                new Teacher
                {
                    FirstName = "Mahboob",
                    LastName = "Ali",
                    Salary = 85000
                });

                context.SaveChanges();
            }
        }
    }
}
