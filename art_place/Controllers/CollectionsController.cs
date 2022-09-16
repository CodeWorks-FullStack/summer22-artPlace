using System;
using System.Collections.Generic;
using art_place.Models;
using art_place.Services;
using Microsoft.AspNetCore.Mvc;

namespace art_place.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CollectionsController : ControllerBase
  {
    private readonly CollectionPiecesService _collectionPiecesService;

    public CollectionsController(CollectionPiecesService collectionPiecesService)
    {
      _collectionPiecesService = collectionPiecesService;
    }

    [HttpGet("{id}/pieces")]
    public ActionResult<List<CollectionPieceViewModel>> GetPieces(int id)
    {
      try
      {
        List<CollectionPieceViewModel> pieces = _collectionPiecesService.GetPiecesByCollectionId(id);
        return Ok(pieces);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}