﻿using Consesionaria.Data;
using Consesionaria.Repositories.Interfaces;

namespace Consesionaria.Repositories.Implementaciones
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Delete(int? id)
        {
            var entity = GetById(id);//se fija si existe el campo

            if (entity == null)
            {
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }

        }

        public IEnumerable<T> GetAll()
        {
            var aux = _db.Set<T>().ToList();//llama todos la lista de elementos
            return aux;
        }

        public T GetById(int? id)
        {
            var aux = _db.Set<T>().Find(id);//trae cosa de la base de datos
            return aux;
        }

        public void Insert(T entity)
        {
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);//modifica campo exisente
        }

    }
}
