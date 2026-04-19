using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController(IPlatformRepo repository,IMapper mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetPlatforms()
    {
        var platformItems = repository.GetAllPlatforms();
        return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public IActionResult GetPlatformById(int id)
    {
        var platformItem = repository.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(mapper.Map<PlatformReadDto>(platformItem));
        }
        return NotFound();
    }
    [HttpPost]
    public IActionResult CreatePlatform([FromBody]PlatformCreateDto platformCreateDto)
    {
        var platformModel = mapper.Map<Models.Platform>(platformCreateDto);
        repository.CreatePlatform(platformModel);
        repository.SaveChanges();
        var platformReadDto = mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
    }

}