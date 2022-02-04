using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;
using api.Models;
using api.Filters;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiKey]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository _memberRepo;
    private readonly ITokenRepository _tokenRepo;

    public MembersController(IMemberRepository memberRepo, ITokenRepository tokenRepo)
    {
        _memberRepo = memberRepo;
        _tokenRepo = tokenRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(NewMember newMember)
    {
        var member = new Member
        {
            Created_at = DateTime.Now,
            Email = newMember.Email,
            Password = newMember.Password,
            Fullname = newMember.Fullname
        };

        await _memberRepo.Add(member);

        return Ok(member);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _memberRepo.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var member = await _memberRepo.Get(id);

        if (member is null) return NotFound();

        return Ok(member);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, NewMember newMember)
    {
        var member = await _memberRepo.Get(id);

        if (member is null) return NotFound();

        member.Email = newMember.Email;
        member.Password = newMember.Password;
        member.Fullname = newMember.Fullname;

        await _memberRepo.Update(member);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var member = await _memberRepo.Get(id);

        if (member is null) return NotFound();

        await _memberRepo.Remove(member);

        return NoContent();
    }

    [HttpPost]
    [Route("Signin")]
    public async Task<IActionResult> Signin(Login login)
    {
        var member = await _memberRepo.Login(login);

        if (member is null) return NotFound();

        var token = await _tokenRepo.Get(member.Id);

        if (token is null) {
            token = new Token
            {
                Content = DateTime.Now.ToString(),
                Member_id = member.Id
            };

            await _tokenRepo.Add(token);
        }

        return Ok(token);
    }

    [HttpDelete]
    [Route("Signout")]
    public async Task<IActionResult> Signout(string member_id)
    {
        var token = await _tokenRepo.Get(member_id);

        if (token is null) return NotFound();

        await _tokenRepo.Remove(token);

        return NoContent();
    }
}
