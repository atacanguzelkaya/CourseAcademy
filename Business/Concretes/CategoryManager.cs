using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Dtos.Categories.Requests;
using Business.Dtos.Categories.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            var category = _mapper.Map<Category>(createCategoryRequest);
            var createdCategory = await _categoryDal.AddAsync(category);
            return _mapper.Map<CreatedCategoryResponse>(createdCategory);
        }

        public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            var gettedCategory = await _categoryDal.GetAsync(c => c.Id == deleteCategoryRequest.Id);
            var deleteCategory = await _categoryDal.DeleteAsync(gettedCategory);
            return _mapper.Map<DeletedCategoryResponse>(deleteCategory);
        }

        public async Task<GettedCategoryByIdResponse> GetById(GetCategoryByIdRequest getCategoryByIdRequest)
        {
            var getByIdCategory = await _categoryDal.GetAsync(c => c.Id == getCategoryByIdRequest.Id);
            return _mapper.Map<GettedCategoryByIdResponse>(getByIdCategory);
        }

        public async Task<IPaginate<GetListedCategoryResponse>> GetListAsync()
        {
            var getList = await _categoryDal.GetListAsync();
            return _mapper.Map<Paginate<GetListedCategoryResponse>>(getList);
        }

        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryrequest)
        {
            //var update = _mapper.Map<Category>(updateCategoryrequest);

            var category = _mapper.Map<Category>(updateCategoryrequest);
            var updatedCategory = await _categoryDal.UpdateAsync(category);
            return _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        }
    }
}