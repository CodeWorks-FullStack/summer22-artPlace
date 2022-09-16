using System;
using System.Collections.Generic;
using art_place.Models;
using art_place.Repositories;

namespace art_place.Services
{
  public class CollectionPiecesService
  {
    private readonly CollectionPiecesRepository _collectionPiecesRepo;
    private readonly CollectionsService _collectionsService;
    private readonly PiecesService _pieceService;

    public CollectionPiecesService(CollectionPiecesRepository collectionPiecesRepo, CollectionsService collectionsService, PiecesService pieceService)
    {
      _collectionPiecesRepo = collectionPiecesRepo;
      _collectionsService = collectionsService;
      _pieceService = pieceService;
    }

    internal List<CollectionPieceViewModel> GetPiecesByCollectionId(int collectionId)
    {
      return _collectionPiecesRepo.GetPiecesByCollectionId(collectionId);
    }

    // NOTE kinda crazy way to return the piece when a COLLECTION PIECE is created
    internal CollectionPieceViewModel Create(CollectionPiece newCollectionPiece, string userId)
    {
      //  is this your collection? can you add pieces to it?
      Collection collection = _collectionsService.GetById(newCollectionPiece.CollectionId);
      if (collection.CreatorId != userId)
      {
        throw new Exception("you are not the owner of that collection, can't add piece");
      }
      // create the collection pieces
      int id = _collectionPiecesRepo.Create(newCollectionPiece);
      //   Get the original piece
      CollectionPieceViewModel collectionPiece = _pieceService.GetViewModelById(newCollectionPiece.PieceId);
      //   attach collectionpiece id to it for the view model
      collectionPiece.CollectionPieceId = id;
      //   return to user
      return collectionPiece;
    }
  }
}