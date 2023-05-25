namespace RefaccionariaBackendApi.Interface
{
    public interface IRepository<T>where T : class
    {
        Task<List<T>>GetAll();
        Task<T> Get(object Id);
        Task<T>Create(T model);
        Task<T> Update(T model);
        Task Delete(T model);
    }
}
