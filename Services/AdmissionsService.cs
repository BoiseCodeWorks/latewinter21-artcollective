using System;
using System.Collections.Generic;
using latewinter_artcollective.Models;
using latewinter_artcollective.Repositories;

namespace latewinter_artcollective.Services
{
  public class AdmissionsService
  {
    private readonly AdmissionsRepository _repo;

    public AdmissionsService(AdmissionsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Admission> GetAll()
    {
      return _repo.GetAll();
    }

    internal Admission GetById(int id)
    {
      Admission data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Admission Create(Admission newAdmission)
    {
      return _repo.Create(newAdmission);
    }

    internal Admission Edit(Admission updated)
    {

      Admission data = GetById(updated.Id);

      data.Date = updated.Date != null ? updated.Date : data.Date;

      return _repo.Edit(data);
    }
    internal string Delete(int id, string userId)
    {
      GetById(id);
      _repo.Delete(id, userId);
      return "delorted";
    }

    internal IEnumerable<Admission> GetAdmissionsByProfileId(string id)
    {
      return _repo.GetByProfileId(id);
    }
  }
}