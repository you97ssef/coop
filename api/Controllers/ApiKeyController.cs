using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("ApiKey")]
public class ApiKeyController : ControllerBase
{
    private const string ApiKeyHeaderName = "ApiKey";
    private readonly IKeyRepository _repository;
    IConfiguration _configuration;

    public ApiKeyController(IKeyRepository repository, IConfiguration configuration)
    {
        _configuration = configuration;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string fullname)
    {
        var key = new ApiKey{
            Fullame = fullname
        };

        await _repository.Add(key);

        return Ok(new {
            Fullname = key.Fullame,
            ApiKey = _configuration.GetValue<string>(ApiKeyHeaderName)
        });
    }
}
