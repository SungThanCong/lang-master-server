using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Application.Catalog.Accounts;
using server.Application.Catalog.Attendances;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Centers;
using server.Application.Catalog.Classes;
using server.Application.Catalog.ColumnTranscripts;
using server.Application.Catalog.Courses;
using server.Application.Catalog.Employees;
using server.Application.Catalog.Exams;
using server.Application.Catalog.Lecturers;
using server.Application.Catalog.Levels;
using server.Application.Catalog.Notifications;
using server.Application.Catalog.Parameters;
using server.Application.Catalog.Students;
using server.Application.Catalog.Teachings;
using server.Application.Catalog.TestTypes;
using server.Application.Catalog.TimeFrames;
using server.Application.Common;
using server.Application.System.Auth;
using server.Data.EF;
using server.Data.Entities;
using server.Uilities.Constants;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace server.BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 

         
            var Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(Logger);


            IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();

            // Add services to the container.
            builder.Services.AddDbContext<LangDbContext>(options =>
                {   
              
                    options.UseLazyLoadingProxies(true);
                    options.UseSqlServer(builder.Configuration.GetConnectionString("LangcenterDatabase"));
                }
            );
            // Add services to the container.
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<LangDbContext>()
                .AddDefaultTokenProviders();

         
         


            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()
                                                                .AllowAnyHeader()
                                                              .AllowAnyMethod());
            });

            builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            builder.Services.AddTransient<JwtService, JwtService>();

            builder.Services.AddSingleton(configuration);

            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IBillService, BillService>();
            builder.Services.AddTransient<IAttendanceService, AttendanceService>();
            builder.Services.AddTransient<IClassService, ClassService>();
            builder.Services.AddTransient<IColumnTranscriptService, ColumnTranscriptService>();
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<ICourseTypeService, CourseTypeService>();

            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IExamService, ExamService>();
            builder.Services.AddTransient<ILecturerService, LecturerService>();
            builder.Services.AddTransient<ILevelService, LevelService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IParameterService, ParameterService>();
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<ITeachingService, TeachingService>();
            builder.Services.AddTransient<ITestTypeService, TestTypeService>();
            builder.Services.AddTransient<ITimeFrameService, TimeFrameService>();


            //builder.Services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //    options.JsonSerializerOptions.WriteIndented = true;

            //});
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
                }
            );

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Tokens:Issuer"],
                    ValidAudience = builder.Configuration["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"])),
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken _, TokenValidationParameters __) =>
                    {
                        if (expires != null && expires > DateTime.UtcNow)
                        {
                            return true;
                        }
                        return false;
                    },
                    RoleClaimType = ClaimTypes.Role,
                };
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //app.UseSerilogRequestLogging(); 

            //app.UseLoggingMiddleware();


            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAnyOrigin");

            app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}