namespace latewinter_artcollective.Models
{
  public class Artist
  {
    public Artist()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? Age { get; set; }
  }

}