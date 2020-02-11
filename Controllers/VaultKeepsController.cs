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
    private readonly KeepsService _ks;
    public VaultKeepsController(VaultKeepsService vks, KeepsService ks)
    {
      _vks = vks;
      _ks = ks;
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

    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeeps(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetKeepsByVaultId(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultId}/keeps/{keepId}")]
    public ActionResult<String> Delete(int keepId)
    {
      try
      {
        return Ok(_ks.Delete(keepId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
