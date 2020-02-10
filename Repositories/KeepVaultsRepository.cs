using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // internal VaultKeep Find(VaultKeep vk)
    // {
    //   string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @KeepId AND vaultId = @VaultId AND userId = @UserId)";
    //   return _db.QueryFirstOrDefault(sql, vk);
    // }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
            INSERT INTO vaultkeeps 
            (keepId, vaultId, userId) 
            VALUES 
            (@KeepId, @VaultId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal void Delete(VaultKeep vk)
    {
      int id = vk.Id;
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}