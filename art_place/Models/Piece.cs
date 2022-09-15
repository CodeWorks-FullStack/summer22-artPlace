namespace art_place.Models
{
  public class Piece
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool ForSale { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}