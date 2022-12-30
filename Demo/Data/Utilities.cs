using Demo.Models;
using System.Security.Principal;

namespace Demo.Data
{
    public class Utilities
    {
        public static void SetRole(Employee employee, string role)
        {
            // Setting role-dependent data
            if (role == "CEO")
            {
                employee.IsManager = false;
                employee.IsCEO = true;
            }
            else if (role == "Manager")
            {
                employee.IsCEO = false;
                employee.IsManager = true;
            }
            else
            {
                employee.IsCEO = false;
                employee.IsManager = false;
            }
        }

        public static void SetSalary(Employee employee, string role, int rank)
        {
            double salaryCoefficient;

            // Setting role-dependent data
            if (role == "CEO")
            {
                salaryCoefficient = 2.725;
            }
            else if (role == "Manager")
            {
                salaryCoefficient = 1.725;
            }
            else
            {
                salaryCoefficient = 1.125;
            }

            // Calculating salary
            employee.Salary = (decimal)(rank * salaryCoefficient);
        }

        public static Employee CreateEmployee(int identity, string firstName, string lastName, string role, int rank, int managerId)
        {
            Employee employee = new Employee();
            

            employee.Id = identity;
            employee.FirstName = firstName;
            employee.LastName = lastName;

            if ( managerId != 0) {
                employee.ManagerId = managerId;
            } else
            {
                employee.ManagerId = null;
            }

            SetRole(employee, role);
            SetSalary(employee, role, rank);

            return employee;
        }

        public static Employee EditEmployee(Employee employee, string firstName, string lastName, string role, int rank, int managerId)
        {
            employee.FirstName = firstName;
            employee.LastName = lastName;

            if (managerId == 0 || managerId == employee.Id) // incoming manager is 0 or same as edited employee
            {
                employee.ManagerId = null;
            }
            else
            {
                employee.ManagerId = managerId; 
            }

            SetRole(employee, role);
            SetSalary(employee, role, rank);

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
