namespace latewinter_artcollective.Models
{
  public class Painting
  {
    public Painting()
    {
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? Year { get; set; }
    public int ArtistId { get; set; }

    //you only need to add this if you are trying to populate
    public Artist Artist { get; set; }
  }
}