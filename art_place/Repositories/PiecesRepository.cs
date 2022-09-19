using System.Collections.Generic;
using System.Data;
using System.Linq;
using art_place.Interfaces;
using art_place.Models;
using Dapper;

namespace art_place.Repositories
{
  public class PiecesRepository : IRepo<Piece, int>
  {
    private readonly IDbConnection _db;

    public PiecesRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Piece> GetAll()
    {
      string sql = @"
        SELECT 
        p.*,
        a.* 
        FROM pieces p
        JOIN accounts a ON a.id = p.creatorId;
      ";
      //   NOTE p pieces is first in sql, so its first in the Data order, the a profile comes second.  The third data type in the the order it the RETURNED type or what data model is being mapped on.
      //                              table1, table2, return T,    table1, table2
      List<Piece> pieces = _db.Query<Piece, Profile, Piece>(sql, (piece, profile) =>
      {
        piece.Creator = profile;
        // return T
        return piece;
      }).ToList();
      return pieces;
    }

    internal CollectionPieceViewModel GetViewModelById(int id)
    {
      string sql = @"
      SELECT * FROM pieces
      WHERE id = @id;
      ";
      CollectionPieceViewModel piece = _db.Query<CollectionPieceViewModel>(sql, new { id }).FirstOrDefault();
      return piece;
    }

    public Piece Create(Piece newPiece)
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

    public Piece GetOne(int id)
    {
      throw new System.NotImplementedException();
    }

    public Piece Update(Piece update)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}