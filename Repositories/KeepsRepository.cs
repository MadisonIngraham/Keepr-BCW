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
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"INSERT INTO keeps (name, description, img, userId) VALUES (@Name, @Description, @Img, @UserId);";
      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}