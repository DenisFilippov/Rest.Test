using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest.Test.Domain.Dto;

namespace Rest.Test.Host.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    public PeopleController()
    {

    }

    [HttpGet()]
    public async Task<IActionResult> GetPeopleAsync()
    {
      return Ok("Not implemented (GetPeopleAsync).");
    }

    [HttpPost()]
    public async Task<IActionResult> CreatePersonAsync([FromBody] Person person)
    {
      return Ok($"Not implemented (CreatePersonAsync = {person.Id}, {person.FistsName}, " +
                $"{person.MiddleName}, {person.LastName}, {person.Age}, {person.Sex}).");
    }

    [HttpGet("new")]
    public async Task<IActionResult> CreatePersonFormAsync()
    {
      return Ok("Not implemented (CreatePersonFormAsync).");
    }

    [HttpGet("{id}/edit")]
    public async Task<IActionResult> EditPersonFormAsync(long id)
    {
      return Ok($"Not implemented (EditPersonFormAsync = {id}).");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonAsync(long id)
    {
      return Ok($"Not implemented (GetPersonAsync = {id}).");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePersonAsync(long id)
    {
      return Ok($"Not implemented (UpdatePersonAsync = {id}).");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonAsync(long id)
    {
      return Ok($"Not implemented (DeletePersonAsync = {id}).");
    }
  }
}
