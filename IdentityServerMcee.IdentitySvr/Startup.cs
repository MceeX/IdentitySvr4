using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServerMcee.IdentitySvr
{
  public class Startup
  {
    public IConfiguration _configuration { get; }

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      var clients = _configuration.GetSection("IdentityServer:Clients");
      services.AddIdentityServer()
              .AddDeveloperSigningCredential()
              .AddInMemoryApiScopes(_configuration.GetSection("apiScopes"))
              .AddInMemoryApiResources(Config.GetAllApiResources())
              //.AddInMemoryClients(_configuration.GetSection("IdentityServer:Clients"));
              .AddInMemoryClients(Config.GetClients());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseIdentityServer();
    }
  }
}
