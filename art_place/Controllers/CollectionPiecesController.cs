using System;
using System.Threading.Tasks;
using art_place.Models;
using art_place.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace art_place.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CollectionPiecesController : ControllerBase
  {
    private readonly CollectionPiecesService _collectionPiecesService;

    public CollectionPiecesController(CollectionPiecesService collectionPiecesService)
    {
      _collectionPiecesService = collectionPiecesService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CollectionPieceViewModel>> Create([FromBody] CollectionPiece newCollectionPiece)
    {
      try
      {
        // pass get user information
        Account user = await HttpContext.GetUserInfoAsync<Account>();
        // pass the new many to many object and the userInfo for verification down the line
        CollectionPieceViewModel piece = _collectionPiecesService.Create(newCollectionPiece, user.Id);
        return Ok(piece);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}