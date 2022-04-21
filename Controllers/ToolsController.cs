using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly ToolService _toolService;

        public ToolsController(ToolService toolService)
        {
            _toolService = toolService;
        }

        [HttpGet]
        public ActionResult<List<Tool>> Get() =>
            _toolService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTool")]
        public ActionResult<Tool> Get(string id)
        {
            var tool = _toolService.Get(id);

            if (tool == null)
            {
                return NotFound();
            }

            return tool;
        }

        [HttpPost]
        public ActionResult<Tool> Create(Tool tool)
        {
            _toolService.Create(tool);

            return CreatedAtRoute("GetTool", new { id = tool.Id.ToString() }, tool);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Tool toolIn)
        {
            var tool = _toolService.Get(id);

            if (tool == null)
            {
                return NotFound();
            }

            _toolService.Update(id, toolIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var tool = _toolService.Get(id);

            if (tool == null)
            {
                return NotFound();
            }

            _toolService.Remove(id);

            return NoContent();
        }
    }

}