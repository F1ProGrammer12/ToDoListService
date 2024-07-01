using Microsoft.EntityFrameworkCore;
using ToDoListService.Dal.EF;
using ToDoListService.Domain.Abstractions.Repositories;
using ToDoListService.Host.Middlewares;
using ToDoService.Core.Interfaces;
using ToDoService.Core.Services;
using ToDoService.Dal.Repositories;
using ToDoService.Logic.Interfaces;
using ToDoService.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TDListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListServiceDb")));

builder.Services.AddTransient<IToDoItemsService, ToDoItemsService>();
builder.Services.AddTransient<IToDoItemsRepository, ToDoItemRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandling();

app.MapControllers();

app.Run();