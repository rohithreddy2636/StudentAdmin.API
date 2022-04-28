using AutoMapper;
using StudentAdmin.API.Domain_Models;
using DataModels=StudentAdmin.API.Data_Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdmin.API.Profiles.After_Maps;

namespace StudentAdmin.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();

            CreateMap<DataModels.Gender, Gender>().ReverseMap();

            CreateMap<DataModels.Address, Address>().ReverseMap();

            CreateMap<UpdateStudentRequest, DataModels.Student>()
                .AfterMap<UpdateRequestStudentAfterMap>();
        }
    }
}
