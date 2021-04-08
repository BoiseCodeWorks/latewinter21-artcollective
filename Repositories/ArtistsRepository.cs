using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latewinter_artcollective.Models;

namespace latewinter_artcollective.Repositories
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Artist> GetAll()
    {
      string sql = "SELECT * FROM artists;";
      return _db.Query<Artist>(sql);
    }

    internal Artist GetById(int Id)
    {
      string sql = "SELECT * FROM artists WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Artist>(sql, new { Id });
    }

    internal Artist Create(Artist newArtist)
    {
      string sql = @"
      INSERT INTO artists
      (name, description, age)
      VALUES
      (@Name, @Description, @Age);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newArtist);
      newArtist.Id = id;
      return newArtist;
    }

    internal Artist Edit(Artist updatedArtist)
    {
      string sql = @"
      UPDATE artists
      SET
        name = @Name,
        description = @Description,
        age = @Age
      WHERE id = @Id;
      SELECT * FROM artists WHERE id = @Id;";
      Artist returnArtist = _db.QueryFirstOrDefault<Artist>(sql, updatedArtist);
      return returnArtist;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM artists WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}