using Demo.Models;
using System.Security.Principal;

namespace Demo.Data
{
    public class Utilities
    {
        public static Employee CreateEmployee(int identity, string firstName, string lastName, string role, int rank, int managerId)
        {
            Employee employee = new Employee();
            double salaryCoefficient;

            employee.Id = identity;
            employee.FirstName = firstName;
            employee.LastName = lastName;

            // Setting role-dependent data
            if (role == "CEO")
            {
                employee.IsManager = false;
                employee.IsCEO = true;

                salaryCoefficient = 2.725;
            }
            else if (role == "Manager")
            {
                employee.IsCEO = false;
                employee.IsManager = true;

                salaryCoefficient = 1.725;
            }
            else
            {
                employee.IsCEO = false;
                employee.IsManager = false;

                salaryCoefficient = 1.125;
            }

            // Calculate salary
            employee.Salary = (decimal)(rank * salaryCoefficient);

            if ( managerId != 0) {
                employee.ManagerId = managerId;
            } else
            {
                employee.ManagerId = null;
            }

            return employee;
        }

        internal static Employee EditEmployee(Employee employee, string firstName, string lastName, string role, int rank, string managerId)
        {
            throw new NotImplementedException();
        }
    }
}
