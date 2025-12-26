using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Services
{

    public class TodoService : ITodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItemDTO>> GetAllAsync()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        public async Task<TodoItemDTO?> GetByIdAsync(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            return item == null ? null : ItemToDTO(item);
        }

        public async Task<TodoItemDTO> CreateAsync(TodoItemDTO dto)
        {
            var item = new TodoItem
            {
                Name = dto.Name,
                IsComplete = dto.IsComplete
            };

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return ItemToDTO(item);
        }

        public async Task<bool> UpdateAsync(long id, TodoItemDTO dto)
        {
            if (id != dto.Id) return false;

            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return false;

            item.Name = dto.Name;
            item.IsComplete = dto.IsComplete;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return false;

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        private static TodoItemDTO ItemToDTO(TodoItem item) =>
            new TodoItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete
            };
    }

}
