using coreWebAPI.Extensions;
using WebApi.Data.Repository.DataBase;
using WebApi.Data.Repository.Repository.Addresses;
using WebApi.Data.Repository.Repository.Faculties;
using WebApi.Data.Repository.Repository.Standards;
using WebApi.Data.Repository.Repository.Students;
using WebApi.Data.Repository.Repository.Subjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DBContextExtension<SchoolDBContext>(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IStandardRepository, StandardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
