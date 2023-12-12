using AutoMapper;
using Business.Dtos.Courses.Requests;
using Business.Dtos.Courses.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();
            CreateMap<Course, GetListedCourseResponse>().ForMember(destinationMember: p => p.CategoryName,
                            memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Course, GetListedCourseResponse>().ForMember(destinationMember: p => p.InstructorName,
                memberOptions: opt => opt.MapFrom(p => p.Instructor.Name)).ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>().ReverseMap();
        }
    }
}