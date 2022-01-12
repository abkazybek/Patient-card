using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFSample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFSample.Controllers
{
    public class HomeController : Controller
    {


        public HomeController(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PatientsAsync()
        {
            return View(await Context.patients.ToListAsync());
        }

        public async Task<IActionResult> DoctorsAsync()
        {
            return View(await Context.doctors.ToListAsync());
        }

        public async Task<IActionResult> DiseasesAsync()
        {
            return View(await Context.diseases.ToListAsync());
        }

    }

}
