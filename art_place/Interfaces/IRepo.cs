using System.Collections.Generic;

namespace art_place.Interfaces
{
  interface IRepo<T, TId>
  {
    T Create(T body);
    List<T> GetAll();
    T GetOne(TId id);
    T Update(T update);
    void Delete(TId id);

  }
}