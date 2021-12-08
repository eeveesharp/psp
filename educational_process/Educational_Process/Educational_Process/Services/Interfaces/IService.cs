using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll(); // получение всех объектов

        T GetById(int id); // получение одного объекта по id

        void Create(T item); // создание объекта

        void Edit(int id, T item); // обновление объекта

        void Delete(int id); // удаление объекта по id
    }
}
