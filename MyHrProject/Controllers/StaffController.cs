using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHrProject.Data;
using MyHrProject.Models;
using MyHrProject.Services.Interface;

namespace MyHrProject.Controllers;

public class StaffController : Controller
{
    private readonly MyHrProjectContext _context;
    private readonly ILogger<StaffController> _logger;
    private readonly IStaffService _staffservice;

    public StaffController(MyHrProjectContext context, ILogger<StaffController> logger, IStaffService service)
    {
        _context = context;
        _logger = logger;
        _staffservice = service;
    }

    // GET: Staff
    public async Task<IActionResult> Index()
    {
        var allstaff = await _staffservice.ReturnAllStaff().ToListAsync();
        Problem("Entity set 'MyHrProjectContext.Staff'  is null.");
        return View(allstaff);
    }

    // GET: Staff/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var staff = await _staffservice.GetStaffById(id);
        if (staff == null) return NotFound();
        _logger.LogInformation("Staff Page Viewed");

        return View(staff);
    }

    // GET: Staff/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Staff/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind(
            "Id,FirstName,MiddleName,LastName,Address,WorkPhoneNumber,PersonalPhoneNumber,Emailaddress,DateOfBirth,EmergencyContactFullName,EmergencyContactFullName,EmergencyContactPhoneNumber,RelationshipToEmployee")]
        Staff staff)
    {
        if (ModelState.IsValid)
        {
            staff.Id = Guid.NewGuid();
            _context.Add(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(staff);
    }

    // GET: Staff/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) return NotFound();

        var staff = await _context.Staff.FindAsync(id);
        if (staff == null) return NotFound();
        return View(staff);
    }

    // POST: Staff/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName")] Staff staff)
    {
        if (id != staff.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(staff.Id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(staff);
    }

    // GET: Staff/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null) return NotFound();

        var staff = await _context.Staff
            .FirstOrDefaultAsync(m => m.Id == id);
        if (staff == null) return NotFound();

        return View(staff);
    }

    // POST: Staff/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var staff = await _context.Staff.FindAsync(id);
        if (staff != null) _context.Staff.Remove(staff);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StaffExists(Guid id)
    {
        return _context.Staff.Any(e => e.Id == id);
    }
}