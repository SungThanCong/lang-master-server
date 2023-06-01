using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Application.Catalog.Accounts;
using server.Application.Common;
using server.Application.System.Auth;
using server.Data.EF;
using server.Data.Entities;
using server.Uilities.Constants;

namespace server.BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<LangDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LangcenterDatabase")));
            // Add services to the container.
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<LangDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            builder.Services.AddTransient<JwtService, JwtService>();
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IUserService, UserService>();


            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;
            });

             // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

         

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}