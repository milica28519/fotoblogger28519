using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fotoblogger.API.Core;
using Fotoblogger.Application;
using Fotoblogger.Application.Commands;
using Fotoblogger.Application.Email;
using Fotoblogger.Application.Queries;
using Fotoblogger.EfDataAccess;
using Fotoblogger.Implementation.Commands;
using Fotoblogger.Implementation.Email;
using Fotoblogger.Implementation.Logging;
using Fotoblogger.Implementation.Queries;
using Fotoblogger.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Fotoblogger.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);

            services.AddTransient<FotobloggerContext>();
            services.AddAutoMapper(this.GetType().Assembly);

            services.AddTransient<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender(appSettings.EmailFrom, appSettings.EmailPassword));
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
            services.AddTransient<EditPostValidator>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<EditRoleValidator>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            services.AddTransient<IGetRoleQuery, EfGetRoleQuery>();
            services.AddTransient<IGetPostQuery, EfGetPostQuery>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IGetPhotoQuery, EfGetPhotoQuery>();
            services.AddTransient<IGetPhotosQuery, EfGetPhotosQuery>();
            services.AddTransient<ScorePhotoValidator>();
            services.AddTransient<IScorePhotoCommand, EfScorePhotoCommand>(); 
            services.AddTransient<IRemovePhotoScoreCommand, EfRemovePhotoScoreCommand>();
            services.AddTransient<CreatePostCommentValidator>();
            services.AddTransient<ICreatePostCommentCommand, EfCreatePostCommentCommand>();
            services.AddTransient<EditPostCommentValidator>();
            services.AddTransient<IEditPostCommentCommand, EfEditPostCommentCommand>();
            services.AddTransient<IDeletePostCommentCommand, EfDeletePostCommentCommand>();
            services.AddTransient<IGetPostCommentsQuery, EfGetPostCommentsQuery>();
            services.AddTransient<IGetPostCommentRepliesQuery, EfGetPostCommentRepliesQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<SetUserProfilePhotoValidator>();
            services.AddTransient<ISetUserProfilePhotoCommand, EfSetUserProfilePhotoCommand>();
            services.AddTransient<IRemoveUserProfilePhotoCommand, EfRemoveUserProfilePhotoCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IDeactivateUserCommand, EfDeactivateUserCommand>();
            services.AddTransient<ActivateUserValidator>();
            services.AddTransient<IActivateUserCommand, EfActivateUserCommand>();
            services.AddTransient<ChangeUserRoleValidator>();
            services.AddTransient<IChangeUserRoleCommand, EfChangeUserRoleCommand>();
            services.AddTransient<ChangeUserUseCasesValidator>();
            services.AddTransient<IChangeUserUseCasesCommand, EfChangeUserUseCasesCommand>();
            services.AddTransient<IGetUserPermissionsQuery, EfGetUserPermissionsQuery>();
            services.AddTransient<AddCommentVoteValidator>();
            services.AddTransient<IAddCommentVoteCommand, EfAddCommentVoteCommand>();
            services.AddTransient<IRemoveCommentVoteCommand, EfRemoveCommentVoteCommand>();
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();
            services.AddTransient<UseCaseExecutor>(); 

            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });


            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<FotobloggerContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();
            app.UseStaticFiles();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
