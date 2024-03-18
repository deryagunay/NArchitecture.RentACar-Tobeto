using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeletedBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandCommand command)
        {
            return Ok( await Mediator.Send(command));
        }

        //public async Task<IActionResult> GetAllAsync()
        //{
        //    return Ok(await Mediator.Send(new GetAllBrandsQuery()));

        //}
    }
}
