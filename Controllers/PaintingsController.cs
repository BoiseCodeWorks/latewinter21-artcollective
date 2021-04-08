using System;
using System.Collections.Generic;
using latewinter_artcollective.Models;
using latewinter_artcollective.Services;
using Microsoft.AspNetCore.Mvc;

namespace latewinter_artcollective.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PaintingsController : ControllerBase
  {

    private readonly PaintingsService _service;

    public PaintingsController(PaintingsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Painting>> Get()
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
    public ActionResult<Painting> Get(int id)
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
    public ActionResult<Painting> Create([FromBody] Painting newProd)
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
    public ActionResult<Painting> Edit([FromBody] Painting updated, int id)
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
    public ActionResult<Painting> Delete(int id)
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

  }
}