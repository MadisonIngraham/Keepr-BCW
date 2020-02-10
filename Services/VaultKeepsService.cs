using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal void Create(VaultKeep newData)
    {
      // VaultKeep exists = _repo.Find(newData);
      // if (exists != null) { throw new Exception("This is already in your collection"); }
      _repo.Create(newData);
    }

    internal string Delete(VaultKeep vk)
    {
      VaultKeep exists = _repo.Find(vk);
      if (exists == null) { throw new Exception("Invalid id combination"); }
      _repo.Delete(exists);
      return "Successfully Deleted";
    }
  }
}