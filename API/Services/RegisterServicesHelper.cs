using BL.Contracts;
using BL.Contracts.UserSevice;
using BL.Services;
using DAL.Contracts;
using DAL.Data;
using DAL.Repositories;
using DAL.UserModel;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySolution.BL.Mapping;
using Serilog;

namespace API.Services
{
	public class RegisterServicesHelper
	{
		public static void RegisterServices(WebApplicationBuilder builder)
		{


			//#1
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/Login";
					options.AccessDeniedPath = "/access-denied";
				});
			//#2
			builder.Services.AddDbContext<AppDbContext>(options =>
				 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			//    .AddCookie(options =>
			//    {
			//        options.LoginPath = "/Login";
			//        options.AccessDeniedPath = "/AccessDenied";
			//    });
			////#3


			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{

				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = true;

			}).AddEntityFrameworkStores<AppDbContext>()
			.AddDefaultTokenProviders();
			//#4
			builder.Services.AddAuthorization();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.AccessDeniedPath = "/admin/Account/AccessDenied";
				options.Cookie.Name = "Cookie";
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
				options.LoginPath = "/admin/Account/Login";
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
				options.SlidingExpiration = true;
			});


			// Configure Serilog for logging
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.MSSqlServer(
					connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
					tableName: "Log",
					autoCreateSqlTable: true)
				.CreateLogger();
			builder.Host.UseSerilog();

			//It is prepared for the first time at the beginning of the application.
			builder.Services.AddScoped<ContextConfig>();
			//--

			builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


			builder.Services.AddScoped(typeof(ITbRepository<>), typeof(TbRepository<>));
			builder.Services.AddScoped(typeof(IVwRepository<>), typeof(VwRepository<>));
			////--
			builder.Services.AddScoped<IUserService, UserService>();
			////--
			builder.Services.AddScoped<IVwSEQuestion, VwSEQuestionService>();
			builder.Services.AddScoped<IVwSubjectTaughtExam, VwSubjectTaughtExamService>();
			builder.Services.AddScoped<IExam, ExamService>();
			builder.Services.AddScoped<IUserAnswer, UserAnswerService>();
			builder.Services.AddScoped<IQuestion, QuestionService>();
			builder.Services.AddScoped<IUserExam, UserExamService>();
			builder.Services.AddScoped<ISubjectsTaught, SubjectsTaughtService>();





		}
	}
}
