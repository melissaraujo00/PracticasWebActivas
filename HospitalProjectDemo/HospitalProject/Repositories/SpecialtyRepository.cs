using HospitalProject.Data;
using HospitalProject.Models;

namespace HospitalProject.Repositories
{
    public class SpecialtyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SpecialtyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<SpecialtyModel> GetAll()
        {
            return _applicationDbContext.Specialties.ToList();
        }

        public SpecialtyModel GetById(int id)
        {
            return _applicationDbContext.Specialties.FirstOrDefault(p => p.Id == id);
        }

        public void Add(SpecialtyModel specialtyModel)
        {
            _applicationDbContext.Specialties.Add(specialtyModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(SpecialtyModel specialtyModel)
        {
            _applicationDbContext.Specialties.Update(specialtyModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id) {
            var specialty = _applicationDbContext.Specialties.Find(id);

            if (specialty != null)
            {
                _applicationDbContext.Specialties.Remove(specialty);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
