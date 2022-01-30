using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("channels/{channel_id}/posts")]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _repository;

    public MessagesController(IMessageRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(string channel_id, NewMessage newMessage)
    {
        var now = DateTime.Now;

        var message = new Message
        {
            Created_at = now,
            Modified_at = now,
            Content = newMessage.Content,
            Conversation_id = channel_id,
            Member_id = newMessage.Member_id
        };

        await _repository.Add(message);
        
        return Ok(message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string channel_id, string id)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        return Ok(message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string channel_id, string id, string newMessage)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        message.Modified_at = DateTime.Now;
        message.Content = newMessage;

        await _repository.Update(message);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string channel_id, string id)
    {
        var message = await _repository.Get(id);

        if (message is null) return NotFound();

        await _repository.Remove(message);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetConversation(string channel_id)
    {
        var messages = await _repository.GetConversationMessages(channel_id);

        if (messages is null) return NotFound();

        return Ok(messages);
    }
}
