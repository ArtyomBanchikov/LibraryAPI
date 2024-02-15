using Library.BLL.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBllServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Library.API.Mappers.MappingProfile), typeof(Library.BLL.Mappers.MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
