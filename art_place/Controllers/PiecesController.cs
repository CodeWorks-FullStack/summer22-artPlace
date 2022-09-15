using System;
using System.Collections.Generic;
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
  public class PiecesController : ControllerBase
  {
    private readonly PiecesService _piecesService;

    public PiecesController(PiecesService piecesService)
    {
      _piecesService = piecesService;
    }

    [HttpGet]
    public ActionResult<List<Piece>> GetAll()
    {
      try
      {
        List<Piece> pieces = _piecesService.GetAll();
        return Ok(pieces);
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    [Authorize]
    // NOTE task return type is here for the async request
    public async Task<ActionResult<Piece>> Create([FromBody] Piece newPiece)
    {
      try
      {
        // assign creatorId to piece.
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newPiece.CreatorId = userInfo.Id;
        Piece piece = _piecesService.Create(newPiece);
        piece.Creator = userInfo;
        return Ok(piece);
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
  }
}