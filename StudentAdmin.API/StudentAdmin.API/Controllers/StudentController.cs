using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.API.Domain_Models;
using StudentAdmin.API.Student_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdmin.API.Data_Models;

namespace StudentAdmin.API.Controllers
{
    [ApiController]

    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var Students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Domain_Models.Student>>(Students));

            //var DomainModelStudents = new List<Student>();

            //foreach(var Student in Students)
            //{
            //    DomainModelStudents.Add(new Student()
            //    {
            //        Id = Student.Id,
            //        FirstName = Student.FirstName,
            //        LastName = Student.LastName,
            //        DateOfBirth = Student.DateOfBirth,
            //        Email = Student.Email,
            //        Mobile = Student.Mobile,
            //        ProfileImageUrl = Student.ProfileImageUrl,
            //        GenderId = Student.GenderId,
            //        Address = new Address()
            //        {
            //            Id =Student.Address.Id,
            //            PhysicalAddress=Student.Address.PhysicalAddress,
            //            PostalAddress= Student.Address.PostalAddress
            //        },
            //        Gender = new Gender()
            //        {
            //            Id= Student.Gender.Id,
            //            Description= Student.Gender.Description
            //        }

            //    });
            //}
            //return Ok(DomainModelStudents);
        }


        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        // [Route("api/[controller]")]
        // [ApiController]

        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Domain_Models.Student>(student));

        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await studentRepository.Exists(studentId))
            {
                // update student
                var updatedstudent = await studentRepository.UpdateStudent(studentId, mapper.Map<Data_Models.Student>(request));
                if (updatedstudent != null)
                {
                    return Ok(mapper.Map<Domain_Models.Student>(updatedstudent));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
          if( await studentRepository.Exists(studentId))
            {
                var student = await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Domain_Models.Student>(student));

            }

            return NotFound();
        }
    }
}

