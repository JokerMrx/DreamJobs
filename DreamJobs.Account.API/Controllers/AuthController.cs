using DreamJobs.Account.API.Contracts.Auth;
using DreamJobs.Account.Core.Models.DTOs;
using DreamJobs.Account.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Account.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthRepository authRepository) : Controller
{
    private readonly ResponseDto _responseDto = new();

    [HttpPost("login")]
    public async Task<ResponseDto> EmployeeLogin([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var token = await authRepository.Login(loginRequest.Email, loginRequest.Password);
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
            var token = await authRepository.EmployeeRegister(employeeRegisterRequest);
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
            var token = await authRepository.EmployerRegister(employerRegisterRequest);
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