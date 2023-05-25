using Microsoft.EntityFrameworkCore;
using Refaccionaria.Data;
using RefaccionariaBackendApi.Interface;
using RefaccionariaBackendApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
/* Configuracion de conexcion a la base de datos */
builder.Services.AddDbContext<RefaccionariaDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RefaccionariaConnection"));
});
var app = builder.Build();
/*Crea la base de datos cada que inicia el servidor */
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RefaccionariaDBContext>();
    context.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
