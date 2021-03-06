using System.Collections.Generic;
using latewinter_artcollective.Models;
using latewinter_artcollective.Services;
using Microsoft.AspNetCore.Mvc;

namespace latewinter21_artcollective.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _pservice;
    private readonly AdmissionsService _admservice;

    public ProfilesController(ProfilesService pservice, AdmissionsService admservice)
    {
      _pservice = pservice;
      _admservice = admservice;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        return Ok(_pservice.GetProfileById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}/admissions")]
    public ActionResult<IEnumerable<Admission>> GetAdmissions(string id)
    {
      try
      {
        return Ok(_admservice.GetAdmissionsByProfileId(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}