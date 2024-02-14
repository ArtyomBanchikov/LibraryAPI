namespace Library.BLL.Interfaces
{
    public interface IGenericService<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken ct);
        Task<TModel> GetByIdAsync(int id, CancellationToken ct);
        Task<TModel> CreateAsync(TModel model, CancellationToken ct);
        Task<TModel> UpdateAsync(int id, TModel model, CancellationToken ct);
        Task DeleteByIdAsync(int id, CancellationToken ct);
    }
}
