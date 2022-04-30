using StudentAdmin.API.Data_Models;
using StudentAdmin.API.Student_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAdmin.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
       
        {
            this.context = context;
        }

       

        public async Task<List<Student>> GetStudentsAsync()
        {
           return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingstudent = await GetStudentAsync(studentId);

            if(existingstudent != null)
            {
                existingstudent.FirstName = request.FirstName;
                existingstudent.LastName = request.LastName;
                existingstudent.DateOfBirth = request.DateOfBirth;
                existingstudent.Email = request.Email;
                existingstudent.Mobile = request.Mobile;
                existingstudent.GenderId = request.GenderId;
                existingstudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingstudent.Address.PostalAddress = request.Address.PostalAddress;

                await context.SaveChangesAsync();
                return existingstudent;
                    
            }

            return null;    
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            var student = await GetStudentAsync(studentId);

            if(student != null)
            {
                context.Student.Remove(student);
               await context.SaveChangesAsync();
                return student;
            }

            return null;
        }
    }
}
