using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Tests
{
    [TestClass]
    public class TodoItemsControllerTests
    {
        private Mock<ITodoService> _mockService;
        private TodoItemsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<ITodoService>();
            _controller = new TodoItemsController(_mockService.Object);
        }

        #region GET: api/TodoItems
        [TestMethod]
        public async Task GetTodoItems_ReturnsOkResult()
        {
            _mockService.Setup(s => s.GetAllAsync())
                        .ReturnsAsync(new List<TodoItemDTO>());
            var result = await _controller.GetTodoItems();
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }
        #endregion

        #region GET: api/TodoItems/{id}
        [TestMethod]
        public async Task GetTodoItem_ReturnsNotFound_WhenMissing()
        {
            _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TodoItemDTO?)null);
            var result = await _controller.GetTodoItem(1);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }
        #endregion

        #region POST: api/TodoItems
        [TestMethod]
        public async Task PostTodoItem_ReturnsCreatedAtAction()
        {
            var dto = new TodoItemDTO { Id = 1, Name = "Test", IsComplete = false };
            _mockService.Setup(s => s.CreateAsync(dto)).ReturnsAsync(dto);
            var result = await _controller.PostTodoItem(dto);
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
        }
        #endregion

        #region PUT: api/TodoItems/{id}
        [TestMethod]
        public async Task PutTodoItem_ReturnsNoContent_WhenUpdated()
        {
            var dto = new TodoItemDTO { Id = 1, Name = "Test", IsComplete = true };
            _mockService.Setup(s => s.UpdateAsync(1, dto)).ReturnsAsync(true);
            var result = await _controller.PutTodoItem(1, dto);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        #endregion

        #region DELETE: api/TodoItems/{id}
        [TestMethod]
        public async Task DeleteTodoItem_ReturnsNoContent_WhenDeleted()
        {
            _mockService.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);
            var result = await _controller.DeleteTodoItem(1);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        #endregion
    }
}