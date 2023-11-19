namespace PedidosApp.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> ObtenerTodos();
    Task<T> Agregar(T entity);

    Task Eliminar(Guid id);
}