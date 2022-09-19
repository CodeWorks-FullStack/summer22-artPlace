namespace art_place.Models
{
  public class Piece : RepoItem<int>
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public bool ForSale { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    // public int CollectionPieceId { get; set; }
  }

  public class CollectionPieceViewModel : Piece
  {
    public int CollectionPieceId { get; set; }
  }
}