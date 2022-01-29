using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;
using api.Models;

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
        var now = DateTime.Now;

        var conversation = new Conversation
        {
            Created_at = now,
            Modified_at = now,
            Label = newConversation.Label,
            Topic = newConversation.Topic
        };

        await _repository.Add(conversation);
        
        return Ok(conversation);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var conversation = await _repository.Get(id);

        if (conversation is null) return NotFound();

        return Ok(conversation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, NewConversation newConversation)
    {
        var conversation = await _repository.Get(id);

        if (conversation is null) return NotFound();

        conversation.Modified_at = DateTime.Now;
        conversation.Label = newConversation.Label;
        conversation.Topic = newConversation.Topic;

        await _repository.Update(conversation);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var conversation = await _repository.Get(id);

        if (conversation is null) return NotFound();

        await _repository.Remove(conversation);

        return NoContent();
    }
}
