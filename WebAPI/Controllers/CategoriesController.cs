using Business.Abstracts;
using Business.Dtos.Categories.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromQuery] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _categoryService.Add(createCategoryRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _categoryService.Update(updateCategoryRequest); return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _categoryService.Delete(deleteCategoryRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCategoryByIdRequest getCategoryByIdRequest)
        {
            var result = await _categoryService.GetById(getCategoryByIdRequest);
            return Ok(result);
        }
    }
}