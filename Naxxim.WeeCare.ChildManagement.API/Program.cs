using MediatR;
using Microsoft.EntityFrameworkCore;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Data;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChildManagementDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddSingleton<IRMQParentVerification, RMQParentVerification>();
builder.Services.AddControllers();
builder.Services.AddScoped<IChildRepository,ChildRepository>();
builder.Services.AddScoped<IincidentRepository, IncidentRepository>();
builder.Services.AddScoped<IjournalRepository,Journalrepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ParentIdConsumer>();
var app = builder.Build();
var serviceProvider = app.Services;
using (var scope = serviceProvider.CreateScope())
{
    var rabbitMQService = scope.ServiceProvider.GetService<ParentIdConsumer>();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
