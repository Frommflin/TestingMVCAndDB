using Demo.Models;

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

            // Setting role-dependent data
            if (role == "Manager")
            {
                employee.IsCEO = false;
                employee.IsManager = true;

                salaryCoefficient = 1.725;
            }
            else if (role == "CEO")
            {
                employee.IsManager = false;
                employee.IsCEO = true;

                salaryCoefficient = 2.725;
            }
            else
            {
                employee.IsCEO = false;
                employee.IsManager = false;

                salaryCoefficient = 1.125;
            }

            // Calculate salary
            employee.Salary = (decimal)(rank * salaryCoefficient);

            //Assign ManagerId if incoming value is an int (possible to come in empty in case of CEO and Manager)
            if (int.TryParse(managerId, out int id))
            {
                employee.ManagerId = id;
            }

            return employee;
        }

        internal static Employee EditEmployee(Employee employee, string firstName, string lastName, string role, int rank, string managerId)
        {
            throw new NotImplementedException();
        }
    }
}
