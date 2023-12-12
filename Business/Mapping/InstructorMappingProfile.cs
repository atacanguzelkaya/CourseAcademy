using AutoMapper;
using Business.Dtos.Instructors.Requests;
using Business.Dtos.Instructors.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetListedInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>().ReverseMap();
        }
    }
}
