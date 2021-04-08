using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using latewinter_artcollective.Models;
using latewinter_artcollective.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace latewinter_artcollective.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _service;
    private readonly PaintingsService _ps;

    public ArtistsController(ArtistsService service, PaintingsService ps)
    {
      _service = service;
      _ps = ps;
    }

    [HttpGet]
    public ActionResult<Artist> Get()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Artist> Create([FromBody] Artist newProd)
    {
      try
      {
        return Ok(_service.Create(newProd));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Artist> Edit([FromBody] Artist updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Artist> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    //https://localhost:5001/api/artists/1/paintings
    [HttpGet("{id}/paintings")]
    public ActionResult<IEnumerable<Painting>> GetPaintings(int id)
    {
      try
      {
        return Ok(_ps.GetByArtistId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}