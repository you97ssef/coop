using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversationsController : ControllerBase
{
    private readonly IConversationRepository _repository;

    public ConversationsController(IConversationRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(NewConversation newConversation)
    {
        var conversation = await _repository.CreateConversation(newConversation);
        return Ok(conversation);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var conversations = await _repository.GetConversations();
        return Ok(conversations);
    }
}
