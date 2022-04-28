using StudentAdmin.API.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmin.API.Student_Repository
{
   public interface IStudentRepository
    {
      Task<List<Student>> GetStudentsAsync();

        Task<Student> GetStudentAsync(Guid studentId);

        Task<List<Gender>>  GetGenderAsync();

       Task<bool> Exists(Guid studentId);

       Task<Student> UpdateStudent(Guid studentId, Student request);
    }
}
