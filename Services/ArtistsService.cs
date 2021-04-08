using System;
using System.Collections.Generic;
using latewinter_artcollective.Models;
using latewinter_artcollective.Repositories;

namespace latewinter_artcollective.Services
{
  public class ArtistsService
  {
    private readonly ArtistsRepository _repo;

    public ArtistsService(ArtistsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Artist> GetAll()
    {
      return _repo.GetAll();
    }

    internal Artist GetById(int id)
    {
      Artist data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Artist Create(Artist newProd)
    {
      return _repo.Create(newProd);
    }

    internal Artist Edit(Artist updated)
    {

      // REVIEW
      Artist data = GetById(updated.Id);

      //null check properties you are editing in repo
      data.Description = updated.Description != null ? updated.Description : data.Description;
      data.Name = updated.Name != null ? updated.Name : data.Name;
      data.Age = updated.Age != null ? updated.Age : data.Age;

      return _repo.Edit(data);
    }
    internal string Delete(int id)
    {
      Artist data = GetById(id);
      _repo.Delete(id);
      return "delorted";
    }
  }
}