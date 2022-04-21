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
    }
}
