using Application.Contracts.User;
using Domain;
using Dtos.Users;
using DTOS.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyTaskInteview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IPersonAccountRepository _personAccountRepository;
        private readonly IMediator _mediator;
        private readonly UserManager<Person> _userManager;

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger,
            IPersonAccountRepository personAccountRepository,
            IMediator mediator, UserManager<Person> userManager)
        {
            _logger = logger;
            _personAccountRepository = personAccountRepository;
            _mediator = mediator;
            _userManager = userManager;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> SigUP([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personAccountRepository.Registration(registrationModel);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);


        }

        [HttpPost("Login"), Authorize]
        public async Task<IActionResult> LogIN([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personAccountRepository.Login(loginModel);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

       
        [HttpPost("AddRole"),Authorize]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personAccountRepository.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }


    }
}