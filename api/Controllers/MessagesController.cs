using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _repository;

    public MessagesController(IMessageRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(NewMessage newMessage)
    {
        var now = DateTime.Now;

        var message = new Message
        {
            Created_at = now,
            Modified_at = now,
            Content = newMessage.Content,
            Conversation_id = newMessage.Conversation_id,
            Member_id = newMessage.Member_id
        };

        await _repository.Add(message);
        
        return Ok(message);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        return Ok(message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, string newMessage)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        message.Modified_at = DateTime.Now;
        message.Content = newMessage;

        await _repository.Update(message);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        await _repository.Remove(message);

        return NoContent();
    }

    [HttpGet("conv/{conversation_id}")]
    public async Task<IActionResult> GetConversation(string conversation_id)
    {
        var messages = await _repository.GetConversationMessages(conversation_id);

        if (messages is null) return NotFound();

        return Ok(messages);
    }
}
