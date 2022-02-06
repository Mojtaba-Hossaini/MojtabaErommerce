using API.Errors;
using API.Helpers;
using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Exctensions;
public static class ApplicationServicesExctensions
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = ActionContext =>
            {
                var errors = ActionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                .SelectMany(c => c.Value.Errors)
                .Select(c => c.ErrorMessage).ToArray();
                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(errorResponse);
            };
        });

        return builder;
    }
}