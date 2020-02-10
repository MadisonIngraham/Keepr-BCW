using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    public ActionResult<String> Create([FromBody] VaultKeep newData)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newData.UserId = userId;
        _vks.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}/keeps")]
    // public ActionResult<IEnumerable<Keep>> GetKeepsByRelId(int id)
    // {
    //   try
    //   {
    //     return Ok(_vks.GetKeepsByRelId(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


    [HttpDelete]
    public ActionResult<String> Delete(VaultKeep vk)
    {
      try
      {
        return Ok(_vks.Delete(vk));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
