using Application.Features.Departments.Query.GetDepartmentDetailsIncludeEmployess;
using Application.Features.Persons.Command.CreatePerson;
using Application.Features.Persons.Command.DeletePerson;
using Application.Features.Persons.Command.UpdatePerson;
using Application.Features.Persons.Query.FilterPerson;
using Application.Features.Persons.Query.GetAllPerson;
using Application.Features.Persons.Query.GetPersonDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyTaskInteview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddPerson")]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommant command)
        {
            try
            {
                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPerson([FromQuery] GetAllPersonQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("FilterPerson")]
        public async Task<IActionResult> GetFilterPerson([FromQuery] FilterPersonQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetailsPerson([FromBody] GetPersonDetailsQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetDetailsPersonWithAddresses")]
        public async Task<IActionResult> GetDetailsPersonWithAddresses([FromQuery] GetPersonDetailsIncludeAddressesQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete]
        public async Task<IActionResult> DeletePerson([FromBody] DeletePersonCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
