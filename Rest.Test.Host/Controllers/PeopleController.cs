using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rest.Test.Domain;
using Rest.Test.Domain.Dto;
using Rest.Test.Domain.Interfaces;

namespace Rest.Test.Host.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
      _personService = personService ?? throw new ArgumentNullException(nameof(personService));
    }

    [HttpGet]
    public async Task<IActionResult> GetPeopleAsync()
    {
      try
      {
        var result = await _personService.GetPeopleAsync();
        return Ok(result);
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersonAsync([FromBody] PersonDto person)
    {
      try
      {
        await _personService.CreatePersonAsync(person);
        return Ok(new ResponseDto {Code = 200});
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() {Code = 500, Error = new ErrorDto {Message = ex.Message}});
      }
    }

    [HttpGet("new")]
    public async Task<IActionResult> CreatePersonFormAsync()
    {
      try
      {
        var result = await _personService.CreatePersonFormAsync();
        return Ok(result);
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }

    [HttpGet("{id}/edit")]
    public async Task<IActionResult> EditPersonFormAsync(long id)
    {
      try
      {
        var result = await _personService.EditPersonFormAsync(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonAsync(long id)
    {
      try
      {
        var result = await _personService.GetPersonAsync(id);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePersonAsync(long id, [FromBody] PersonDto person)
    {
      try
      {
        var result = await _personService.UpdatePersonAsync(id, person.FirstName, person.MiddleName, person.LastName,
          person.Age, person.Sex);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonAsync(long id)
    {
      try
      {
        await _personService.DeletePersonAsync(id);
        return Ok(new ResponseDto { Code = 200 });
      }
      catch (Exception ex)
      {
        return Ok(new ResponseDto() { Code = 500, Error = new ErrorDto { Message = ex.Message } });
      }
    }
  }
}