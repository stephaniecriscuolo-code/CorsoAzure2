using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApplicationAPICorsoAzure.Configuration;

namespace WebApplicationAPICorsoAzure.ToDoItemes
{
    public class MockItemsServicecs : ITodoItems
    {
        private readonly IConfiguration configuration;
        private readonly IOptions<AppSettings> appsettings;
        public MockItemsServicecs(IConfiguration configuration, IOptions<AppSettings> appsettings)
        {

            this.configuration = configuration;
            this.appsettings = appsettings;
        }

        private static List<TodoItem> todoItems = new List<TodoItem>
    {
        new TodoItem(1, "1", false, "1"),
        new TodoItem(2, "2", true, "2")
    };

        public string ProvaGetAllItems()
        {
            var miovalore = configuration["MiaChiave"];
            var miovaloreA = configuration["MyKeyComplessa:A"];
            var x = appsettings.Value.A;
            var tot = miovalore + " " + miovaloreA + " " + x.ToString();
            //await Task.Delay(1000);//simula un ritardo di 1 secondo
            return tot;
        }
        public async Task<List<TodoItem>> GetAllItems()
        {
            var miovalore = configuration["MiaChiave"];
            var miovaloreA = configuration["MyKeyComplessa:A"];
            var x = appsettings.Value.A;

            await Task.Delay(1000);//simula un ritardo di 1 secondo
            return todoItems;
        }


        public async Task<TodoItem?> GetItem(int Id)
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id == Id);
            return item;
        }

        public async Task<TodoItem> CreateItem(CreateTodoItem newItem) //mappaggio di oggetti
        {
            await Task.Delay(1000);
            var newID = 1;
            if (todoItems.Count > 0)
                newID = todoItems.Max(i => i.Id) + 1;
            var item = new TodoItem(3, newItem.Title, false, newItem.Category);
            todoItems.Add(item);
            return item;
        }

        public async Task UpdateItem(TodoItem ItemModific) //mappaggio di oggetti
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id == ItemModific.Id);
            if (item is not null)
            {
                var newItemM = item with
                {
                    Title = ItemModific.Title,
                    Category = ItemModific.Category,
                    IsDone = ItemModific.IsDone,
                };
                todoItems.Remove(item);
                todoItems.Add(newItemM);
            }

            // throw new NotImplementedException();
        }
        public async Task DeleteItem(int Id) //mappaggio di oggetti
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id == Id);
            if (item is not null)
            {
                todoItems.Remove(item);
            }

            // throw new NotImplementedException();
        }
    }
}
