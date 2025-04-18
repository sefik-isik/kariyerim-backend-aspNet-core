using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class KariyerimContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=kariyerim;Trusted_Connection=true");
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<CompanyUserAddress> CompanyUserAddresses { get; set; }
        public DbSet<CompanyUserDepartment> CompanyUserDepartments { get; set; }
        public DbSet<CompanyUserFile> CompanyUserFiles { get; set; }
        public DbSet<CompanyUserImage> CompanyUserImages { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PersonelUserCv> PersonelUserCvs { get; set; }
        public DbSet<PersonelUserAbout> PersonelUserAbouts { get; set; }
        public DbSet<PersonelUserCvEducation> PersonelUserCvEducations { get; set; }
        public DbSet<PersonelUserCvSummary> PersonelUserCvSummaries { get; set; }
        public DbSet<PersonelUserCvWorkExperience> PersonelUserCvWorkExperiences { get; set; }
        public DbSet<DriverLicence> DriverLicences { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<LicenceDegree> LicenceDegrees { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TaxOffice> TaxOffices { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
        public DbSet<PersonelUser> PersonelUsers { get; set; }
        public DbSet<PersonelUserAddress> PersonelUserAddresses { get; set; }
        public DbSet<PersonelUserCoverLetter> PersonelUserCoverLetters { get; set; }
        public DbSet<PersonelUserFile> PersonelUserFiles { get; set; }
        public DbSet<PersonelUserImage> PersonelUserImages { get; set; }
        public DbSet<WorkingMethod> WorkingMethods { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ModelMenu> ModelMenus { get; set; }
    }
}
