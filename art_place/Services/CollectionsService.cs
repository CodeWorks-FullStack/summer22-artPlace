using System;
using art_place.Models;
using art_place.Repositories;

namespace art_place.Services
{
  public class CollectionsService
  {
    private readonly CollectionsRepository _collectionsRepo;

    public CollectionsService(CollectionsRepository collectionsRepo)
    {
      _collectionsRepo = collectionsRepo;
    }

    internal Collection GetById(int id)
    {
      Collection collection = _collectionsRepo.GetById(id);
      if (collection == null)
      {
        throw new Exception("No collection by that id");
      }
      return collection;
    }
  }
}