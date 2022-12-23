using Demo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo.Data
{
    public class Utilities
    {
        public static Employee CreateEmployee(string firstName, string lastName, string role, int rank, string managerId)
        {
            Employee employee = new Employee();
            double salaryCoefficient;

            employee.FirstName = firstName;
            employee.LastName = lastName;

            if (role == "Manager")
            {
                employee.IsCEO = false;
                employee.IsManager = true;

                salaryCoefficient = 1.125;
            }
            else if (role == "CEO")
            {
                employee.IsManager = false;
                employee.IsCEO = true;

                salaryCoefficient = 1.725;
            }
            else
            {
                employee.IsCEO = false;
                employee.IsManager = false;

                salaryCoefficient = 2.725;
            }

            // Calculate salary
            employee.Salary = (decimal)(rank * salaryCoefficient);

            if (int.TryParse(managerId, out int id))
            {
                employee.ManagerId = id;
            }

            return employee;
        }
    }
}
