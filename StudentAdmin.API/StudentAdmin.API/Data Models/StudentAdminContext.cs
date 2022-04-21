using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmin.API.Data_Models
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> Options) : base(Options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Address> Address { get; set; }

    }
}
