using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid id."); }
      if (exists.IsPrivate == false)
      {
        return exists;
      }
      throw new Exception("Can't access private content.");
    }

    internal Keep GetByIdWithUser(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid id."); }
      if (exists.IsPrivate == false)
      {
        return exists;
      }
      else if (exists.IsPrivate == true && exists.UserId == userId)
      {
        return exists;
      }
      throw new Exception("Can't access private content.");
    }


    internal Keep Edit(Keep update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid id."); }
      _repo.Edit(update);
      return update;
    }

    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid id."); }
      _repo.Delete(id);
      return "Successfully deleted";
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }
  }
}