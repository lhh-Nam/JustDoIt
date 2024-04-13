using JDI.Infrastructure.Extensions;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddControllers();
builder.Services.RegisterDbContext(builder.Configuration.GetConnectionString("SqlConnectionString"));

var a = builder.Configuration.GetConnectionString("SqlConnectionString");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();



static void Main(string connectionString)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            Console.WriteLine("connected");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

Main(a);

app.Run();
