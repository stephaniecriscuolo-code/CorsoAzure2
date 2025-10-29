namespace WebApplicationAPICorsoAzure.ToDoItemes
{
    public record class TodoItem(int Id, string Title, bool IsDone, string Category); //internal record Serve per creare oggetti (immutabili) in cui conta il contenuto (i valori dei campi) che non cambiano.

    public record CreateTodoItem(string Title, string Category);
    public interface ITodoItems
    {
        Task<List<TodoItem>> GetAllItems();//Task vuol dire che è asincrono
        Task<TodoItem?> GetItem(int Id);
        Task<TodoItem> CreateItem(CreateTodoItem newItem);
        Task UpdateItem(TodoItem ItemModific);
        Task DeleteItem(int Id);
    }
    public interface GenericCrud<T, U>//interfaccia generica; T è il tipo di oggetto su cui si opera, U è il tipo dell'id
    {
        Task<List<T>> GetAllItems();
        Task<T?> GetItem(U Id);
        Task<T> CreateItem(CreateTodoItem newItem);
        Task UpdateItem(T ItemModific);
        Task DeleteItem(U Id);

    }
}
