using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.BAL.Services;
using Portfolio.Model.DTOs;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechnologiesController : ControllerBase
{
    private readonly ITechnologyService _service;

    public TechnologiesController(ITechnologyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TechnologyDto>>> GetAll()
    {
        var technologies = await _service.GetAllAsync();
        return Ok(technologies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TechnologyDto>> GetById(int id)
    {
        var technology = await _service.GetByIdAsync(id);
        if (technology == null)
            return NotFound();

        return Ok(technology);
    }

    [HttpPost]
    public async Task<ActionResult<TechnologyDto>> Create([FromBody] CreateTechnologyDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdTechnology = await _service.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdTechnology.Id }, createdTechnology);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTechnologyDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _service.UpdateAsync(id, updateDto);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
