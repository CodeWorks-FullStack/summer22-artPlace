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
  }
}