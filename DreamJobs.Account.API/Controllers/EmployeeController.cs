using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;
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