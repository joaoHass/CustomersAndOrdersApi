﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);

        /// <summary></summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException">
        /// Should be throwed when the entity, that has
        /// the id passed as parameter, is not found.
        /// </exception>
        void Delete(int id);
    }
}
