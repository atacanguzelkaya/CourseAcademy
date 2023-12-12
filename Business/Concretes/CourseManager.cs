using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Courses.Requests;
using Business.Dtos.Courses.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal;
        private IMapper _mapper;
        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            //Course course = new Course();
            //course.Id = Guid.NewGuid();
            //course.Name = createCourseRequest.Name;
            //course.Description = createCourseRequest.Description;
            //course.Price = createCourseRequest.Price;
            //Course createdCourse = await _courseDal.AddAsync(course);
            //CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            //createdCourseResponse.Id = createdCourse.Id;
            //createdCourseResponse.Name = createCourseRequest.Name;
            //createdCourseResponse.Description = createCourseRequest.Description;
            //createdCourseResponse.Price = createCourseRequest.Price;
            //return createdCourseResponse;

            var course = _mapper.Map<Course>(createCourseRequest);
            var createdCourse = await _courseDal.AddAsync(course);
            return _mapper.Map<CreatedCourseResponse>(createdCourse);
        }

        public async Task<IPaginate<GetListedCourseResponse>> GetListAsync()
        {
            var getList = await _courseDal.GetListAsync(include: p => p.Include(p => p.Category).Include(p => p.Instructor));
            return _mapper.Map<Paginate<GetListedCourseResponse>>(getList);
        }
    }
}