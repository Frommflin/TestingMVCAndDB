using Demo.Models;
using System.Security.Principal;

namespace Demo.Data
{
    public class Utilities
    {
        private static double salaryCoefficient;
        public static Employee CreateEmployee(int identity, string firstName, string lastName, string role, int rank, int managerId)
        {
            Employee employee = new Employee();
            

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

        internal static Employee EditEmployee(Employee employee, string firstName, string lastName, string role, int rank, int managerId)
        {
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

            if (managerId == 0 || managerId == employee.Id) // incoming manager is 0 or same as edited employee
            {
                employee.ManagerId = null;
            }
            else
            {
                employee.ManagerId = managerId; 
            }

            return employee;
        }

        public static string GetRole(bool manager, bool ceo)
        {
            string role;

            if (manager)
            {
                role = "Manager";
            } 
            else if (ceo)
            {
                role = "CEO";
            }
            else
            {
                role = "Employee";
            }

            return role;
        }
    }
}
