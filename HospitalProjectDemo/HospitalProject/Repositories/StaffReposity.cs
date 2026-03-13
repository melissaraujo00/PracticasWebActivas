using HospitalProject.Data;
using HospitalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.Repositories
{
    public class StaffReposity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StaffReposity(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public List<StaffModel> GetAll()
        {
            return _applicationDbContext.Staff
                    .Include(s=> s.StaffCategory)
                    .Include(s => s.Specialty)
                    .ToList();
        }

        public StaffModel GetById(int id)
        {
            return _applicationDbContext.Staff
                    .Include(s => s.StaffCategory)
                    .Include(s => s.Specialty)
                    .FirstOrDefault(sm => sm.Id == id);
        }

        public void Add(StaffModel staffModel)
        {
            _applicationDbContext.Staff.Add(staffModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(StaffModel staffModel)
        {
            _applicationDbContext.Staff.Update(staffModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id) { 
            var staff = _applicationDbContext.Staff.Find(id);

            if (staff != null)
            {
                _applicationDbContext.Staff.Remove(staff);
                _applicationDbContext.SaveChanges();
            }
        }

    }
}
