using Demo.Data;

namespace Demo.Models
{
    public static class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) // Called in Program.cs, line 34
        {
            DemoContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DemoContext>();

            if (!context.Employees.Any()) //if no records exists in table Employees, add this initializing data
            {
                context.AddRange(
                    new Employee { Id = 1233, FirstName = "Björn", LastName = "Björnsson", Salary = (decimal)(10 * 2.725), IsCEO = true, IsManager = false },
                    new Employee { Id = 1454, FirstName = "Lisa", LastName = "Torsson", Salary = (decimal)(9 * 1.725), IsCEO = false, IsManager = true, ManagerId = 1233 },
                    new Employee { Id = 8732, FirstName = "Greta", LastName = "Karlsson", Salary = (decimal)(3 * 1.125), IsCEO = false, IsManager = false, ManagerId = 1454 },
                    new Employee { Id = 3512, FirstName = "Lars", LastName = "Larsson", Salary = (decimal)(2 * 1.125), IsCEO = false, IsManager = false, ManagerId = 1454 },
                    new Employee { Id = 8463, FirstName = "Nisse", LastName = "Liten", Salary = (decimal)(7 * 1.725), IsCEO = false, IsManager = true, ManagerId = 1233 },
                    new Employee { Id = 1845, FirstName = "Maja", LastName = "Gräddnos", Salary = (decimal)(4 * 1.125), IsCEO = false, IsManager = false, ManagerId = 8463 },
                    new Employee { Id = 6204, FirstName = "Pelle", LastName = "Svanslös", Salary = (decimal)(4 * 1.125), IsCEO = false, IsManager = false, ManagerId = 8463 }
                );
            }

            context.SaveChanges();
        }
    }
}
