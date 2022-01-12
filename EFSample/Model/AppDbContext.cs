using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;


namespace EFSample.Model
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> patients { get; set; }

        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Disease> diseases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disease>()
        .HasKey(p => new { p.PatientId, p.DoctorID });
        }
    }
}

