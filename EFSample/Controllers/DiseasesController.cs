using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFSample.Model;

namespace EFSample.Controllers
{
    public class DiseasesController : Controller
    {
        private readonly AppDbContext _context;

        public DiseasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Diseases
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.diseases.Include(d => d.doctor).Include(d => d.patient);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Diseases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases
                .Include(d => d.doctor)
                .Include(d => d.patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // GET: Diseases/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.doctors, "DoctorID", "NameofDoctor");
            ViewData["PatientId"] = new SelectList(_context.patients, "PatientId", "Login");
            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,DoctorID,Diagnosis,Complaint,Date")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.doctors, "DoctorID", "NameofDoctor", disease.DoctorID);
            ViewData["PatientId"] = new SelectList(_context.patients, "PatientId", "Login", disease.PatientId);
            return View(disease);
        }

        // GET: Diseases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.doctors, "DoctorID", "NameofDoctor", disease.DoctorID);
            ViewData["PatientId"] = new SelectList(_context.patients, "PatientId", "Login", disease.PatientId);
            return View(disease);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,DoctorID,Diagnosis,Complaint,Date")] Disease disease)
        {
            if (id != disease.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseaseExists(disease.PatientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.doctors, "DoctorID", "NameofDoctor", disease.DoctorID);
            ViewData["PatientId"] = new SelectList(_context.patients, "PatientId", "Login", disease.PatientId);
            return View(disease);
        }

        // GET: Diseases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.diseases
                .Include(d => d.doctor)
                .Include(d => d.patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disease = await _context.diseases.FindAsync(id);
            _context.diseases.Remove(disease);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseaseExists(int id)
        {
            return _context.diseases.Any(e => e.PatientId == id);
        }
    }
}
