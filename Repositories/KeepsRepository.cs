using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"INSERT INTO keeps (name, description, img, userId, isPrivate) VALUES (@Name, @Description, @Img, @UserId, @IsPrivate);
      SELECT LAST_INSERT_ID()";
      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;
    }


    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal void Edit(Keep update)
    {
      string sql = @"
            UPDATE keeps
            SET 
            name = @Name, description = @Description, img = @Img, userId = @UserId, 
            WHERE id = @Id; 
            ";
      _db.Execute(sql, update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
            SELECT k.*
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId
            WHERE (vk.vaultId = @vaultId AND vk.userId = @userId);";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }
  }
}