namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        ICollection<T> GetAll();
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
