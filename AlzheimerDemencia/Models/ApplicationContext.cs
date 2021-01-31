using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace AlzheimerDemencia.Models
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<MmseSurvey> MmseSurvey { get; set; }
        public DbSet<PatientNote> PatientNote { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<ObservationNote> ObservationNote { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mmse
            modelBuilder.Entity<MmseSurvey>()
                .HasOne(s => s.User)
                .WithMany(a => a.MmseSurveys);

            modelBuilder.Entity<User>()
                .HasMany(s => s.MmseSurveys)
                .WithOne(a => a.User);

            //patientNote
            modelBuilder.Entity<PatientNote>()
                .HasOne(s => s.User)
                .WithMany(a => a.PatientNotes);
            modelBuilder.Entity<User>()
                .HasMany(s => s.PatientNotes)
                .WithOne(a => a.User);

            //treatment
            modelBuilder.Entity<Treatment>()
                .HasOne(s => s.DoctorUserId)
                .WithMany(a => a.TreatmentDoctor);

            modelBuilder.Entity<Treatment>()
                .HasOne(s => s.PatientUserId)
                .WithMany(a => a.TreatmentPatient);

            modelBuilder.Entity<User>()
                .HasMany(s => s.TreatmentPatient)
                .WithOne(a => a.PatientUserId);
            modelBuilder.Entity<User>()
                .HasMany(s => s.TreatmentDoctor)
                .WithOne(a => a.DoctorUserId);

            //observationNote
            modelBuilder.Entity<ObservationNote>()
                .HasOne(s => s.DoctorUserId)
                .WithMany(f => f.ObservationNotes);

            modelBuilder.Entity<User>()
                .HasMany(s => s.ObservationNotes)
                .WithOne(a => a.DoctorUserId);

            modelBuilder.Entity<ObservationNote>()
                .HasOne(s => s.Treatment)
                .WithMany(a => a.ObservationNotes);

            modelBuilder.Entity<Treatment>()
                .HasMany(s => s.ObservationNotes)
                .WithOne(a => a.Treatment);
        }
    }
}
