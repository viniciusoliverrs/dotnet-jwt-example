using Auth.API.Data.Repositories;
using Auth.API.Data.Services;
using Auth.API.Data.ViewModels.Requests;
using Auth.API.Data.ViewModels.Responses;
using Auth.API.Domain.Data.Repositories;
using Auth.API.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("signin")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> SignIn([FromBody] SignInRequest model)
    {
        var user = _userRepository.Exists(model.Username, model.Password);

        if (user == null)
            return NotFound(new CustomResponse("User not found", null));

        var token = TokenService.GenerateToken(user);
        return Ok(new CustomResponse("Login efetuado com sucesso", new SignInResponse(token)));
    }
    [HttpPost]
    [Route("signup")]
    [AllowAnonymous]
    public async Task<ActionResult<CustomResponse>> SignUp([FromBody] SignUpRequest model)
    {
        var isExist = _userRepository.AvailableUserByUsername(model.Username);

        if (isExist)
            return NotFound(new { message = "Já existe um usuário com este username!" });


        _userRepository.Add(new User { Username = model.Username, Password = model.Password, Role = model.Role });

        return Ok(new CustomResponse("Usuário registrado com sucesso!"));
    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
}
