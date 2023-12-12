using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Categories.Requests;
using Business.Dtos.Categories.Responses;
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

        public async Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest)
        {
            var gettedInstructor = await _instructorDal.GetAsync(c => c.Id == deleteInstructorRequest.Id);
            var deleteInstructor = await _instructorDal.DeleteAsync(gettedInstructor);
            return _mapper.Map<DeletedInstructorResponse>(deleteInstructor);
        }

        public async Task<GettedInstructorByIdResponse> GetById(GetInstructorByIdRequest getInstructorByIdRequest)
        {
            var getByIdInstructor = await _instructorDal.GetAsync(c => c.Id == getInstructorByIdRequest.Id);
            return _mapper.Map<GettedInstructorByIdResponse>(getByIdInstructor);
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync()
        {
            var getList = await _instructorDal.GetListAsync();
            return _mapper.Map<Paginate<GetListedInstructorResponse>>(getList);
        }

        public async Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorrequest)
        {
            var instructor = _mapper.Map<Instructor>(updateInstructorrequest);
            var updatedInstructor = await _instructorDal.UpdateAsync(instructor);
            return _mapper.Map<UpdatedInstructorResponse>(updatedInstructor);
        }
    }
}