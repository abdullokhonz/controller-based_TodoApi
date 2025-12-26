using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoItemsController(ITodoService service)
    {
        _service = service;
    }

    #region GET: api/TodoItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }
    #endregion

    #region GET: api/TodoItems/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    #endregion

    #region PUT: api/TodoItems/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoDTO)
    {
        var updated = await _service.UpdateAsync(id, todoDTO);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
    #endregion

    #region POST: api/TodoItems
    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var created = await _service.CreateAsync(todoDTO);
        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = created.Id },
            created);
    }
    #endregion

    #region DELETE: api/TodoItems/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    #endregion
}