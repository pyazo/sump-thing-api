using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SumpThingApi.Clients;
using SumpThingApi.Models;

namespace SumpThingApi
{
  public class Startup
  {
    public Startup (IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services)
    {
      services
        .AddMvc ()
        .SetCompatibilityVersion (CompatibilityVersion.Version_2_1)
        .AddJsonOptions (options =>
        {
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

          options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

          options.SerializerSettings.ContractResolver = new DefaultContractResolver ()
          {
            NamingStrategy = new SnakeCaseNamingStrategy ()
          };
        });

      services.AddCors (options =>
      {
        options.AddPolicy ("AllowLocalFrontend", builder =>
        {
          builder.WithOrigins ("http://localhost:8080")
            .AllowAnyHeader ();
        });
      });

      // Get database stuff setup.
      var connectionString = Environment.GetEnvironmentVariable ("DB_CONNECTION_STRING");

      services.AddDbContext<ApiDbContext> (options => options.UseNpgsql (connectionString));

      // Setup Auth0 Stuff
      string domain = $"https://{Environment.GetEnvironmentVariable("AUTH0_DOMAIN")}/";
      services.AddAuthentication (options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

      }).AddJwtBearer (options =>
      {
        options.Authority = domain;
        options.Audience = Environment.GetEnvironmentVariable ("AUTH0_API_ID");
      });

      services.AddHttpClient ();

      services.AddHttpClient<Auth0Client> ();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment ())
      {
        app.UseDeveloperExceptionPage ();
        app.UseCors ("AllowLocalFrontend");
      }
      else
      {
        app.UseHsts ();
      }

      app.UseAuthentication ();
      app.UseHttpsRedirection ();
      app.UseMvc ();
    }
  }
}