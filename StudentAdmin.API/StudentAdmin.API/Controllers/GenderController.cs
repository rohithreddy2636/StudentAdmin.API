using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdmin.API.Repositories;
using StudentAdmin.API.Student_Repository;
using AutoMapper;
using StudentAdmin.API.Domain_Models;

namespace StudentAdmin.API.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderlist = await studentRepository.GetGenderAsync();

            if (genderlist == null || !genderlist.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderlist));
        }
    }
}
