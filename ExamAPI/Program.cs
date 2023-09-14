using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// add cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
         policy =>
         {
             policy.AllowAnyOrigin();
             policy.AllowAnyMethod();
             policy.AllowAnyHeader();
         }
         );
});
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options
    => options.SerializerSettings.ReferenceLoopHandling
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//

builder.Services.AddDbContext<ExamAPI.Models.Context>(
    opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("ExamAPI"))
); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// use cors
app.UseCors();

app.Run();
