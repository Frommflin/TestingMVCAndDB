using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Models;

namespace Demo.Controllers
{
    public class EmployeesController : Controller
    {
        private static string errorMessage = "";
        private readonly DemoContext _context;

        public EmployeesController(DemoContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            // Ordering data by role. CEO -> Manager -> Employee
            var demoContext = _context.Employees.Include(e => e.Manager).OrderByDescending(x => x.IsCEO).ThenByDescending(x => x.IsManager);

            ViewData["Error"] = errorMessage;

            return View(await demoContext.ToListAsync());
        }

        // GET: Employees/ReturnToIndex
        // Action to reset errormessage before returning to Index page
        public IActionResult ReturnToIndex()
        {
            errorMessage = "";
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Managers"] = new SelectList(_context.Employees.Where(x => x.IsManager == true), "Id", "FirstName", "Id", "Id");
            ViewData["ManagersAndCEO"] = new SelectList(_context.Employees.Where(x => (x.IsCEO == true || x.IsManager == true)), "Id", "FirstName", "Id", "Id");

            Employee ceo = _context.Employees.FirstOrDefault(x => x.IsCEO == true);
            if(ceo == null)
            {
                ViewData["CEOExists"] = false;
            }
            else
            {
                ViewData["CEOExists"] = true;
            }

            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public async Task<IActionResult> Create(int id, string firstName, string lastName, string role, int createRank, int managerId)
        {
            
            Employee employee = Utilities.CreateEmployee(id, firstName, lastName, role, createRank, managerId);

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ReturnToIndex));
            }
            
            return View();
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["Managers"] = new SelectList(_context.Employees.Where(x => x.IsManager == true ), "Id", "FirstName", "Id", "Id");
            ViewData["ManagersAndCEO"] = new SelectList(_context.Employees.Where(x => (x.IsCEO == true || x.IsManager == true)), "Id", "FirstName", "Id", "Id");

            Employee ceo = _context.Employees.FirstOrDefault(x => x.IsCEO == true);
            if (ceo == null || employee.IsCEO == true)
            {
                ViewData["CEOExists"] = false;
            }
            else
            {
                ViewData["CEOExists"] = true;
            }

            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, string firstName, string lastName, string currentRole, string editRole, int editRank, int managerId, [Bind("Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            List<Employee> isManagerToOthers = _context.Employees.Where(x => x.ManagerId == employee.Id).ToList();

            if(isManagerToOthers.Count == 0 || editRole == currentRole) // If no others are managed or the currentRole is same as editRole
            {
                employee = Utilities.EditEmployee(employee, firstName, lastName, editRole, editRank, managerId);

                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ReturnToIndex));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                }
            }
            else // can't edit because employee is managing others
            {
                errorMessage = "Changes were unable to be saved because the chosen person is a manager to other employees!";
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'DemoContext.Employee'  is null.");
            }

            var employee = await _context.Employees.FindAsync(id);
            List<Employee> isManagerToOthers = _context.Employees.Where(x => x.ManagerId == employee.Id).ToList(); //Collection all employees using this employee as manager

            if (isManagerToOthers.Count != 0) //Returns to index with error message if count is not 0
            {
                errorMessage = "Unable to delete person from records because he or she is a manager to other employees!";
                return RedirectToAction(nameof(Index));
            }
            else if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ReturnToIndex));
        }

        private bool EmployeeExists(int id)
        {
          return _context.Employees.Any(e => e.Id == id);
        }
    }
}
