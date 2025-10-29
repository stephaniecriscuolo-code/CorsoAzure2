
#region Services

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterHttpServices();
builder.Services.RegisteredServices(); //metodo di estensione per registrare i servizi personalizzati
#endregion

#region EndPoints
var app = builder.Build();
// Configure the HTTP request pipeline.
//Environment è una variabile di ambiente
if (app.Environment.IsDevelopment())//dfferenziare tra ambiente di sviluppo e produzione, presente anche nelle proprietà del progetto
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // var x = new TodoItem(1, "Titolo", false); //creazione di un oggetto di tipo record
    //var y = x with { IsDone = false };//creazione di un nuovo oggetto di tipo record con una proprietà modificata
}
app.UseMiddleware<GlobalExceptionMiddleware>(); //inserimento del middleware per la gestione globale delle eccezioni
app.RegisterToDoItemsEndopoints(); //metodo di estensione per registrare gli endpoint personalizzati
//verifica conn db
app.MapGet("/product",async (DBContext context) =>
{
   await Task.Delay(1000);
    var data=context.Products;
    return Results.Ok();

});
//risultati da db
app.MapGet("/prod", async (DBContext context) =>
{
    var data = await context.Products.Select
    (p => new ProductDTO { ProductId = p.ProductId,
        ProductName= p.ProductName,
        Category = p.Category.CategoryName }).ToListAsync();
    return Results.Ok(data);

});

app.MapGet("/todoproducts/", (IProducts service) =>
{
    //var items = new List<TodoItem>
    //{
    //    new TodoItem(1, "1", false),
    //    new TodoItem(2, "2", true)
    //};
    // return Results.Ok(items);
    //return Results.NotFound();
    return Results.Ok(service.GetAll());

});//endpoint di default che risponde con il contenuto delle parentesi graffe



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion





