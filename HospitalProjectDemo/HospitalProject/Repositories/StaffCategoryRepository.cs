using HospitalProject.Data;
using HospitalProject.Models;

namespace HospitalProject.Repositories
{
    public class StaffCategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StaffCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<StaffCategoryModel> GetAll()
        {
                return _applicationDbContext.StaffCategories.ToList();
        }

        public StaffCategoryModel GetById(int id)
        {
            return _applicationDbContext.StaffCategories.FirstOrDefault(p => p.Id == id);
        }

        public void Add(StaffCategoryModel staffCategoryModel)
        {
            _applicationDbContext.StaffCategories.Add(staffCategoryModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(StaffCategoryModel staffCategoryModel)
        {
            _applicationDbContext.StaffCategories.Update(staffCategoryModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id) { 
            var StaffCategory = _applicationDbContext.StaffCategories.Find(id);

            if (StaffCategory != null)
            {
                _applicationDbContext.StaffCategories.Remove(StaffCategory);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
