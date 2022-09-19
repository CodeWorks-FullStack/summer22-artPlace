namespace art_place.Models
{
  public class RepoItem<T>
  {
    public T Id { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
  }
}