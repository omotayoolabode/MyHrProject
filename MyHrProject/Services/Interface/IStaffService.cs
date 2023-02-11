using Microsoft.EntityFrameworkCore;
using MyHrProject.Models;

namespace MyHrProject.Services.Interface;

public interface IStaffService
{
    public  Task<Staff?> GetStaffById( Guid id);
    public DbSet<Staff> ReturnAllStaff();
}