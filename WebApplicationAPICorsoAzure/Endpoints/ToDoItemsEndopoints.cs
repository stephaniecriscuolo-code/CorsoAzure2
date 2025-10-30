namespace WebApplicationAPICorsoAzure.Endpoints;

public static class ToDoItemsEndopoints
{
    private static IResult ProvaGetAll(ITodoItems service)
    {
        return Results.Ok(service.ProvaGetAllItems());
    }
    public static void ProvaRegisterToDoItemsEndopoints(this WebApplication app)//stiamo estenendendo i services nella classe
    {
        var group = app.MapGroup("/todoitems");
        group.MapGet("/stepProva", ProvaGetAll);
    }
    private static async Task<IResult> GetAll(ITodoItems service)
    {
        return Results.Ok(await service.GetAllItems());
    }
    public static void RegisterToDoItemsEndopoints(this WebApplication app)//stiamo estenendendo i services nella classe
    {
        var group = app.MapGroup("/todoitems");
        group.MapGet("/step", GetAll);// async (ITodoItems service) =>
                                      //{
                                      //var items = new List<TodoItem>
                                      //{
                                      //    new TodoItem(1, "1", false),
                                      //    new TodoItem(2, "2", true)
                                      //};
                                      // return Results.Ok(items);
                                      //return Results.NotFound();
                                      // });//endpoint di default che risponde con il contenuto delle parentesi graffe
        group.MapGet("/{id}", async (int id, ITodoItems service) =>
        {
            var item = await service.GetItem(id);
            if (item == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(item);
            }
        });
        group.MapPost("/", async (CreateTodoItem newItem, ITodoItems service) =>
        { //oggetto del json
            if (newItem.Category is null) return Results.BadRequest();
            if (newItem.Title is null) return Results.BadRequest();

            var item = await service.CreateItem(newItem);
            //return Results.NoContent();
            return Results.Created($"/todoitems/{item.Id}", item);
        });
        group.MapPut("{id}", async (int id, TodoItem item, ITodoItems service) =>
        {
            if (id != item.Id) return Results.BadRequest();
            await service.UpdateItem(item);
            return Results.NoContent();

        });
        group.MapPatch("{id}", async (int id, TodoItem item, ITodoItems service) => {
            if (id != item.Id) return Results.BadRequest();
            await service.UpdateItem(item);
            return Results.NoContent();

        });
        group.MapDelete("{id}", async (int id, ITodoItems service) => {
            await Task.Delay(1000);
            await service.DeleteItem(id);
            return Results.NoContent();

        });
        group.MapGet("/stephrotto", () =>
        {
            throw new InvalidProgramException("Rosso come la maggica");
        });
    }
}
