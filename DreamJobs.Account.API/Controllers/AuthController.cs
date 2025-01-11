using DreamJobs.Account.API.Contracts.Auth;
using DreamJobs.Account.Application.DTOs;
using DreamJobs.Account.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Account.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : Controller
{
    private readonly ResponseDto _responseDto = new();

    [HttpPost("login")]
    public async Task<ResponseDto> EmployeeLogin([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var token = await authService.Login(loginRequest.Email, loginRequest.Password);
            _responseDto.Result = token;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _responseDto.Message = ex.Message;
        }

        return _responseDto;
    }

    [HttpPost("employees/register")]
    public async Task<ResponseDto> EmployeeRegister([FromBody] EmployeeRegisterRequest employeeRegisterRequest)
    {
        try
        {
            var token = await authService.EmployeeRegister(employeeRegisterRequest);
            _responseDto.Result = token;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _responseDto.Message = ex.Message;
        }

        return _responseDto;
    }

    [HttpPost("employers/register")]
    public async Task<ResponseDto> EmployerRegister([FromBody] EmployerRegisterRequest employerRegisterRequest)
    {
        try
        {
            var token = await authService.EmployerRegister(employerRegisterRequest);
            _responseDto.Result = token;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _responseDto.Message = ex.Message;
        }

        return _responseDto;
    }
}