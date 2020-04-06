using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T, TId>
    {
        IReadOnlyCollection<T> GetAll();
        T Create(T item);
        T GetById(TId id);
    }
}
