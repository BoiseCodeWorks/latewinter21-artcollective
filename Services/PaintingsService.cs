using System;
using System.Collections.Generic;
using latewinter_artcollective.Models;
using latewinter_artcollective.Repositories;

namespace latewinter_artcollective.Services
{
  public class PaintingsService
  {
    private readonly PaintingsRepository _repo;

    public PaintingsService(PaintingsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Painting> GetAll()
    {
      return _repo.GetAll();
    }

    internal Painting GetById(int id)
    {
      Painting data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Painting Create(Painting newProd)
    {
      return _repo.Create(newProd);
    }

    internal Painting Edit(Painting updated)
    {

      // REVIEW
      Painting data = GetById(updated.Id);

      //null check properties you are editing in repo
      data.Description = updated.Description != null ? updated.Description : data.Description;
      data.Title = updated.Title != null ? updated.Title : data.Title;

      //remember if null checking an integer put an Elvis operator ? in the model following the type
      data.Year = updated.Year != null ? updated.Year : data.Year;

      return _repo.Edit(data);
    }
    internal string Delete(int id)
    {
      Painting data = GetById(id);
      _repo.Delete(id);
      return "delorted";
    }

    internal IEnumerable<Painting> GetByArtistId(int id)
    {
      return _repo.GetByArtistId(id);
    }
  }
}