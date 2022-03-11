using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListBlazor.Api.Repositories;
using Task = TodoListBlazor.Api.Entities.Task;

namespace TodoListBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var task = await _taskRepository.GetTaskList();
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _taskRepository.Create(task);
            return CreatedAtAction("Tạo task thành công ", result);
        }
        [HttpGet]
        [Route("{:id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _taskRepository.GetById(id);
            if (result == null)
                return NotFound($"{id} không tồn tại");
            return Ok(result);
        }

        [HttpPut]
        [Route("{:id}")]
        public async Task<IActionResult> Update(Guid id, Entities.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            taskFromDb.Name = task.Name;
            var result = await _taskRepository.Update(taskFromDb);
            return Ok(result);
        }

    }
}
