using Application.Features.Addesses.Commands.DeleteAddress;
using Application.Features.Addesses.Commands.UpdateAddress;
using Application.Features.Addresses.Command.CreateAddress;
using Application.Features.Addresses.Query.FilterAddress;
using Application.Features.Addresses.Query.GetAddressDetails;
using Application.Features.Addresses.Query.GetAllAddress;
using Application.Features.Persons.Query.FilterPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace MyTaskInteview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddAdressForUser")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
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
        [HttpGet("GetAllAddressForUSer")]
        public async Task<IActionResult> GetAllAddressForUSer([FromQuery] GetAllAddressQuery query)
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

        [HttpGet("FilterAddress")]
        public async Task<IActionResult> GetFilterAddress([FromBody] FilterAddressQuery query)
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
        public async Task<IActionResult> GetDetailsAddress([FromQuery] GetAddressDetailsQuery query)
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
        public async Task<IActionResult> DeleteAddress([FromBody] DeleteAddressCommand command)
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
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
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
