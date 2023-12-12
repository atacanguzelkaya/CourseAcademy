using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Instructors.Requests;
using Business.Dtos.Instructors.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private IInstructorDal _instructorDal;
        private IMapper _mapper;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            var instructor = _mapper.Map<Instructor>(createInstructorRequest);
            var createdInstructor = await _instructorDal.AddAsync(instructor);
            return _mapper.Map<CreatedInstructorResponse>(createdInstructor);
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync()
        {
            var getList = await _instructorDal.GetListAsync();
            return _mapper.Map<Paginate<GetListedInstructorResponse>>(getList);
        }
    }
}