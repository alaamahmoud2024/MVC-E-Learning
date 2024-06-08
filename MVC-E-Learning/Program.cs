using BLL.Interfaces;
using BLL.Repository;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_E_Learning.MappingProfiles;

namespace MVC_E_Learning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LearningDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Key"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            //builder.Services.AddAutoMapper(typeof(ContactProfile).Assembly);


            builder.Services.AddIdentity<AppUser , IdentityRole>()
                .AddEntityFrameworkStores<LearningDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}