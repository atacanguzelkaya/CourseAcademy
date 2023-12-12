using Business.Abstracts;
using Business.Dtos.Instructors.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromQuery] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.Add(createInstructorRequest); return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.Update(updateInstructorRequest); return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteInstructorRequest deleteInstructorRequest)
        {
            var result = await _instructorService.Delete(deleteInstructorRequest); return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList()
        {
            var result = await _instructorService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetInstructorByIdRequest getInstructorByIdRequest)
        {
            var result = await _instructorService.GetById(getInstructorByIdRequest);
            return Ok(result);
        }
    }
}