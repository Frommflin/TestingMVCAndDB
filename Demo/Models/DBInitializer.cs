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
                    new Employee { FirstName = "Björn", LastName = "Björnsson", Salary = 234455, IsCEO = true, IsManager = false },
                    new Employee { FirstName = "Lisa", LastName = "Torsson", Salary = 21354, IsCEO = false, IsManager = true, ManagerId = 1 },
                    new Employee { FirstName = "Greta", LastName = "Karlsson", Salary = 12345, IsCEO = false, IsManager = false, ManagerId = 2 },
                    new Employee { FirstName = "Lars", LastName = "Larsson", Salary = 23456, IsCEO = false, IsManager = false, ManagerId = 2 },
                    new Employee { FirstName = "Nisse", LastName = "Liten", Salary = 13542, IsCEO = false, IsManager = true, ManagerId = 1 },
                    new Employee { FirstName = "Maja", LastName = "Gräddnos", Salary = 76432, IsCEO = false, IsManager = false, ManagerId = 5 },
                    new Employee { FirstName = "Pelle", LastName = "Svanslös", Salary = 32456, IsCEO = false, IsManager = false, ManagerId = 5 }
                );
            }

            context.SaveChanges();
        }
    }
}
