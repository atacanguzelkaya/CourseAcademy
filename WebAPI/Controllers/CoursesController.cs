using Business.Abstracts;
using Business.Dtos.Categories.Requests;
using Business.Dtos.Courses.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromQuery] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.Add(createCourseRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.Update(updateCourseRequest); return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCourseRequest deleteCourseRequest)
        {
            var result = await _courseService.Delete(deleteCourseRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetCourseByIdRequest getCourseByIdRequest)
        {
            var result = await _courseService.GetById(getCourseByIdRequest);
            return Ok(result);
        }
    }
}