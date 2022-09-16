using System.Data;
using System.Linq;
using art_place.Models;
using Dapper;

namespace art_place.Repositories
{
  public class CollectionsRepository
  {
    private readonly IDbConnection _db;

    public CollectionsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Collection GetById(int id)
    {
      string sql = @"
      SELECT * FROM collections
      WHERE id = @id;
      ";
      Collection collection = _db.Query<Collection>(sql, new { id }).FirstOrDefault();
      return collection;
    }
  }
}