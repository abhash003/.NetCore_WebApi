using coreWebAPI.Extensions;
using WebApi.Data.Repository.DataBase;
using WebApi.Data.Repository.Repository.Addresses;
using WebApi.Data.Repository.Repository.Authoriztion;
using WebApi.Data.Repository.Repository.Faculties;
using WebApi.Data.Repository.Repository.Standards;
using WebApi.Data.Repository.Repository.Students;
using WebApi.Data.Repository.Repository.Subjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://cloud.apihealthcare.com/workforce",
            ValidAudience = "https://localhost:7038",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("RfUjXn2r5u8x/A?D(G-KPdSgVkYp3s6v"))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = delegate (MessageReceivedContext context)
            {

                context.Token = context.Request.Headers.Authorization.ToString();

                return Task.CompletedTask;
            },
            OnTokenValidated = delegate (TokenValidatedContext context)
            {
                return Task.CompletedTask;
            },
            OnChallenge = async delegate (JwtBearerChallengeContext context)
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                IProblemDetailsService requiredService = context.HttpContext.RequestServices.GetRequiredService<IProblemDetailsService>();
                ProblemDetails problemDetails = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>().CreateProblemDetails(context.HttpContext, 401, "USER_NOT_AUTHORIZED", null, "The user session is not authorized to access the requested resource.");
                await requiredService.WriteAsync(new ProblemDetailsContext
                {
                    HttpContext = context.HttpContext,
                    ProblemDetails = problemDetails
                }).ConfigureAwait(continueOnCapturedContext: false);
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
