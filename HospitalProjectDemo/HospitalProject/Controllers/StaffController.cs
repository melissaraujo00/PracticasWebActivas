using HospitalProject.Models;
using HospitalProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalProject.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffReposity _staffRepository;
        private readonly StaffCategoryRepository _staffCategoryRepository;
        private readonly SpecialtyRepository specialtyRepository;

        public StaffController(StaffReposity staffRepository, StaffCategoryRepository staffCategoryRepository, SpecialtyRepository specialtyRepository)
        {
            _staffRepository = staffRepository;
            _staffCategoryRepository = staffCategoryRepository;
            this.specialtyRepository = specialtyRepository;
        }

        // GET: SpecialtyController
        public IActionResult Index()
        {
            var staffList = _staffRepository.GetAll();
            return View(staffList);
        }



        // GET: SpecialtyController/Create
        public IActionResult Create()
        {
            var specialties = specialtyRepository.GetAll();
            var staffCategories = _staffCategoryRepository.GetAll();

            ViewBag.Specialties = new SelectList(specialties, nameof(SpecialtyModel.Id), nameof(SpecialtyModel.Name));
            ViewBag.StaffCategories = new SelectList(staffCategories, nameof(StaffCategoryModel.Id), nameof(StaffCategoryModel.Name));

            return View();
        }

        // POST: SpecialtyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffModel staffModel)
        {
            if (!ModelState.IsValid)
            {
                _staffRepository.Add(staffModel);
                return RedirectToAction(nameof(Index));
            }

            return View(staffModel);
        }

        // GET: SpecialtyController/Edit/5
        public IActionResult Edit(int id)
        {
            var staff = _staffRepository.GetById(id);
            if (staff == null) return NotFound();

            var specialties = specialtyRepository.GetAll();
            var staffCategories = _staffCategoryRepository.GetAll();

            ViewBag.Specialties = new SelectList(specialties, nameof(SpecialtyModel.Id), nameof(SpecialtyModel.Name), staff.SpecialtyId);
            ViewBag.StaffCategories = new SelectList(staffCategories, nameof(StaffCategoryModel.Id), nameof(StaffCategoryModel.Name), staff.StaffCategoryId);

            return View(staff);
        }

        // POST: SpecialtyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffModel staffModel)
        {
            if (!ModelState.IsValid)
            {
                _staffRepository.Update(staffModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffModel);
        }

        public IActionResult Delete(int id) { 
            var staff = _staffRepository.GetById(id);
            if (staff == null) return NotFound();
            return View(staff);
        }


        // POST: SpecialtyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StaffModel staffModel)
        {
            _staffRepository.Delete(staffModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
