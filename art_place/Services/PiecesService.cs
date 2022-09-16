using System;
using System.Collections.Generic;
using art_place.Models;
using art_place.Repositories;

namespace art_place.Services
{
  public class PiecesService
  {
    private readonly PiecesRepository _piecesRepo;

    public PiecesService(PiecesRepository piecesRepo)
    {
      _piecesRepo = piecesRepo;
    }

    internal List<Piece> GetAll()
    {
      return _piecesRepo.GetAll();
    }

    internal Piece Create(Piece newPiece)
    {
      return _piecesRepo.Create(newPiece);
    }

    internal Piece GetById(int collectionId)
    {
      throw new NotImplementedException();
    }

    internal CollectionPieceViewModel GetViewModelById(int pieceId)
    {
      CollectionPieceViewModel piece = _piecesRepo.GetViewModelById(pieceId);
      if (piece == null)
      {
        throw new Exception("no piece by that id");
      }
      return piece;
    }
  }
}