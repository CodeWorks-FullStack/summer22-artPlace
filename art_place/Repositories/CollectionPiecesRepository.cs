using System.Collections.Generic;
using System.Data;
using System.Linq;
using art_place.Models;
using Dapper;

namespace art_place.Repositories
{
  public class CollectionPiecesRepository
  {
    private readonly IDbConnection _db;

    public CollectionPiecesRepository(IDbConnection db)
    {
      _db = db;
    }

    // Get the pieces inside of a collection
    internal List<CollectionPieceViewModel> GetPiecesByCollectionId(int collectionId)
    {
      string sql = @"
        SELECT
            cp.*,
            p.*,
            a.*
        FROM collectionpieces cp
            JOIN pieces p ON cp.pieceId = p.id
            JOIN accounts a ON p.creatorId = a.id
        WHERE cp.collectionId = @collectionId;
        ";
      List<CollectionPieceViewModel> pieces = _db.Query<CollectionPiece, CollectionPieceViewModel, Account, CollectionPieceViewModel>(sql, (cp, p, a) =>
      {
        // NOTE converting the 3 objects pulled from the select query into one object
        p.Creator = a;
        p.CollectionPieceId = cp.Id;
        return p;
        // NOTE \/ object with labeled values for dapper to use in sql
      }, new { collectionId }).ToList();
      return pieces;
    }

    internal int Create(CollectionPiece newCollectionPiece)
    {
      string sql = @"
      INSERT INTO collectionpieces
      (pieceId, collectionId)
      VALUES
      (@pieceId, @collectionId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newCollectionPiece);
      return id;
    }
  }
}