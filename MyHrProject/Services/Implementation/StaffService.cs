using Microsoft.EntityFrameworkCore;
using MyHrProject.Data;
using MyHrProject.Models;
using MyHrProject.Services.Interface;

namespace MyHrProject.Services.Implementation;

public class StaffService : IStaffService
{
    private readonly MyHrProjectContext _context;
   

    public StaffService(MyHrProjectContext context)
    {
        _context = context;
    }
    public async Task<Staff?> GetStaffById( Guid id)
    {
        var staff = await _context.Staff.FirstOrDefaultAsync(x => x.Id == id);
        return staff;

    }

    public DbSet<Staff> ReturnAllStaff()
    {
        var allstaff = _context.Staff;
        return allstaff;
    }
}