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
                    new Employee { FirstName = "Björn", LastName = "Björnsson", Salary = (decimal)(10 * 2.725), IsCEO = true, IsManager = false },
                    new Employee { FirstName = "Lisa", LastName = "Torsson", Salary = (decimal)(9 * 1.725), IsCEO = false, IsManager = true, ManagerId = 1 },
                    new Employee { FirstName = "Greta", LastName = "Karlsson", Salary = (decimal)(3 * 1.125), IsCEO = false, IsManager = false, ManagerId = 2 },
                    new Employee { FirstName = "Lars", LastName = "Larsson", Salary = (decimal)(2 * 1.125), IsCEO = false, IsManager = false, ManagerId = 2 },
                    new Employee { FirstName = "Nisse", LastName = "Liten", Salary = (decimal)(7 * 1.725), IsCEO = false, IsManager = true, ManagerId = 1 },
                    new Employee { FirstName = "Maja", LastName = "Gräddnos", Salary = (decimal)(4 * 1.125), IsCEO = false, IsManager = false, ManagerId = 5 },
                    new Employee { FirstName = "Pelle", LastName = "Svanslös", Salary = (decimal)(4 * 1.125), IsCEO = false, IsManager = false, ManagerId = 5 }
                );
            }

            context.SaveChanges();
        }
    }
}
