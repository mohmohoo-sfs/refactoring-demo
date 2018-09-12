using api.GraphQL;
using api.GraphQL.Models;
using api.GraphQL.Models.Inputs;
using api.GraphQL.Models.Outputs;
using api.GraphQL.Mutations;
using api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace graphql_way
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IncomeProtectionQuery>();
            services.AddSingleton<IncomeProtectionMutation>();
            services.AddSingleton<StepResponseModelType>();
            services.AddSingleton<Step1InputType>();
            services.AddSingleton<GenderEnum>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<IDependencyResolver>(new FuncDependencyResolver(type => (IGraphType)sp.GetRequiredService(type)));
            services.AddSingleton<IncomeProtectionV1Schema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
