using System.Collections.Generic;
using System.Data;
using System.Linq;
using art_place.Models;
using Dapper;

namespace art_place.Repositories
{
  public class PiecesRepository
  {
    private readonly IDbConnection _db;

    public PiecesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Piece> GetAll()
    {
      string sql = @"
        SELECT 
        p.*,
        a.* 
        FROM pieces p
        JOIN accounts a ON a.id = p.creatorId;
      ";
      //   NOTE p pieces is first in sql, so its first in the Data order, the a account comes second.  The third data type in the the order it the RETURNED type or what data model is being mapped on.
      //                              table1, table2, return T,    table1, table2
      List<Piece> pieces = _db.Query<Piece, Account, Piece>(sql, (piece, account) =>
      {
        piece.Creator = account;
        // return T
        return piece;
      }).ToList();
      return pieces;
    }

    internal Piece Create(Piece newPiece)
    {
      string sql = @"
        INSERT INTO pieces
        (title, description, imgUrl, forSale, creatorId)
        VALUES
        (@title, @description, @imgUrl, @forSale, @creatorId);
        SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newPiece);
      newPiece.Id = id;
      return newPiece;
    }
  }
}