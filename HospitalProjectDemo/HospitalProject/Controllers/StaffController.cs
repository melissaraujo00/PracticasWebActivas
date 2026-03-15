using HospitalProject.Models;
using HospitalProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffReposity _staffRepository;

        public StaffController(StaffReposity staffRepository)
        {
            _staffRepository = staffRepository;
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
            return View();
        }

        // POST: SpecialtyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffModel staffModel)
        {
            if (ModelState.IsValid)
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

            return View(staff);
        }

        // POST: SpecialtyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffModel staffModel)
        {
            if (ModelState.IsValid)
            {
                _staffRepository.Update(staffModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffModel);
        }



        // POST: SpecialtyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _staffRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
