using DreamJobs.Account.Application.DTOs;
using DreamJobs.Account.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Account.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : Controller
{
    private readonly ResponseDto _responseDto = new();

    [HttpGet]
    [Route("me")]
    public async Task<ActionResult<Employee>> GetMe()
    {
        try
        {
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }
}