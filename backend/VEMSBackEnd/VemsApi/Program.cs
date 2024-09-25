using BusinessObject;
using DataAccess.DAO;
using Microsoft.EntityFrameworkCore;
using SchoolMate.Authorizotion;
using SchoolMate.Helpers;
using VemsApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<VemsContext>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<IGradeService, GradeService>();
<<<<<<< HEAD
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
=======
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96

builder.Services.AddHttpContextAccessor();




builder.Services.AddDbContext<VemsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VEMS"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<JwtMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
